using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SPY.Modules.NativeMethod;

namespace SPY
{
    public partial class SpyForm : Form
    {
        private int HotkeyId = 0;
        private bool ForgroundFlag;
        private bool IsCaptionChanged;
        Dictionary<string, string> itemDict;

        // event_changed radio checked state => ForgroundFlag = false and task done!
        public SpyForm()
        {
            InitializeComponent();
            InitializeHotKey();
            InitializeCommandsLV();
            InitializeSaveListLV();
            SetInitValue();
            StartMonitoringSystem();
        }



        private void StartMonitoringSystem()
        {
            Task.Run(MonitorWindow);
        }

        private void SpyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterHotKey(this.Handle, HotkeyId);
        }

        private void InitializeCommandsLV()
        {

            lvCommands.Clear();
            lvCommands.View = View.Details;
            lvCommands.FullRowSelect = true;
            lvCommands.GridLines = true;

            lvCommands.Columns.Add("Method");
            lvCommands.Columns.Add("Desc");

            itemDict = new();
            itemDict.Add("SetForegroundWindow", "Set Focus");
            itemDict.Add("WM_CLOSE", "Close Window");
            itemDict.Add("SC_MINIMIZE", "Minimize Window");
            itemDict.Add("SW_HIDE", "Hide Window Forced");
            foreach (KeyValuePair<string, string> pair in itemDict)
            {
                ListViewItem item = new ListViewItem(pair.Key);
                item.SubItems.Add(pair.Value);
                lvCommands.Items.Add(item);
            }
            lvCommands.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvCommands.Columns[1].Width = -2;
        }
        private void InitializeSaveListLV()
        {
            lvSaveList.Clear();
            lvSaveList.View = View.Details;
            lvSaveList.FullRowSelect = true;
            lvSaveList.GridLines = true;

            lvSaveList.Columns.Add("No");
            lvSaveList.Columns.Add("Hwnd");
            lvSaveList.Columns.Add("Caption");
        }

        private void SetInitValue()
        {
            rdoForeground.Checked = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);
                int id = m.WParam.ToInt32();

                if (modifier == KeyModifier.Shift && key == Keys.A)
                {
                    if (!IsSaveListDuplicated(txtHwndId.Text))
                    {
                        ListViewItem item = new("0");
                        item.SubItems.Add(txtHwndId.Text);
                        item.SubItems.Add(txtCaption.Text);
                        lvSaveList.Items.Add(item);
                        lvSaveList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
            }
            bool IsSaveListDuplicated(string checkItem)
            {
                foreach (ListViewItem item in lvSaveList.Items)
                {
                    if (item.SubItems[1].Text == checkItem)
                        return true;
                    else
                        return false;
                }
                return false;
            }
        }

        private void InitializeHotKey()
        {
            // save list
            RegisterHotKey(this.Handle, HotkeyId, (int)KeyModifier.Shift, Keys.A.GetHashCode());
        }

        private void MonitorWindow()
        {
            const int nChars = 256;
            StringBuilder captionBuffer = new StringBuilder(nChars);
            StringBuilder classBuffer = new StringBuilder(nChars);
            IntPtr handle;

            while (true)
            {
                handle = GetForegroundWindow();
                if (GetWindowText(handle, captionBuffer, nChars) > 0 && ForgroundFlag)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        txtCaption.Text = captionBuffer.ToString();
                    }));
                    if (IsCaptionChanged)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            txtHwndId.Text = handle.ToInt32().ToString();
                            if (GetClassName(handle, classBuffer, nChars) > 0)
                            {
                                txtClass.Text = classBuffer.ToString();
                            }
                            InitTreeviewNode(GetChildWindows(handle));
                        }));
                        lblRamp.BackColor = Color.LightGreen;
                        IsCaptionChanged = false;
                    }
                }
                else
                {

                    handle = FindWindow(null, txtCaption.Text);
                    if (handle != IntPtr.Zero)
                    {
                        lblRamp.BackColor = Color.LightGreen;
                        this.BeginInvoke(new Action(() =>
                        {
                            txtHwndId.Text = handle.ToInt32().ToString();
                            if (IsCaptionChanged)
                            {
                                if (GetClassName(handle, classBuffer, nChars) > 0)
                                {
                                    txtClass.Text = classBuffer.ToString();
                                }
                                InitTreeviewNode(GetChildWindows(handle));
                            }

                        }));
                    }
                    else
                    {
                        lblRamp.BackColor = Color.OrangeRed;
                        this.BeginInvoke(new Action(() =>
                        {
                            tvChildHwnd.Nodes.Clear();
                        }));
                    }
                    IsCaptionChanged = false;
                    captionBuffer.Clear();
                    classBuffer.Clear();
                }

                Thread.Sleep(500);

            }
        }
        private void InitTreeviewNode(List<IntPtr> childHandles)
        {
            int maxCount = 256;
            List<IntPtr> DuplicatedCheckList = new();

            tvChildHwnd.Nodes.Clear();

            AddNodesRecursive(childHandles, tvChildHwnd.Nodes);

            childHandles.Clear();
            childHandles = null;

            void AddNodesRecursive(List<IntPtr> handles, TreeNodeCollection nodes)
            {

                StringBuilder nodeSb = new();
                StringBuilder captionBuffer = new(maxCount);
                StringBuilder classBuffer = new(maxCount);
                foreach (IntPtr child in handles)
                {
                    if (DuplicatedCheckList.Contains(child))
                    {
                        continue;
                    }
                    DuplicatedCheckList.Add(child);

                    nodeSb.Append(child.ToString());
                    nodeSb.Append("  ");
                    nodeSb.Append('"');
                    if (GetWindowText(child, captionBuffer, maxCount) > 0)
                    {
                        nodeSb.Append(captionBuffer);
                    }
                    nodeSb.Append('"');
                    nodeSb.Append("  ");
                    if (GetClassName(child, classBuffer, maxCount) > 0)
                    {
                        nodeSb.Append(classBuffer);
                    }


                    nodes.Add(nodeSb.ToString());
                    nodeSb.Clear();
                    captionBuffer.Clear();
                    classBuffer.Clear();

                    AddNodesRecursive(GetChildWindows(child), nodes[^1].Nodes);

                }
                nodeSb.Clear();
                nodeSb = null;
                captionBuffer = null;
                classBuffer = null;
            }
            DuplicatedCheckList.Clear();
            DuplicatedCheckList = null;

        }
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            //list.Clear();
            return true;
        }

        private void rdoCaption_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoForeground.Checked)
            {
                ForgroundFlag = true;
            }
            else
            {
                ForgroundFlag = false;
            }
        }

        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            IsCaptionChanged = true;
        }



        IntPtr desktopPtr = IntPtr.Zero;
        private void tvChildHwnd_DoubleClick(object sender, EventArgs e)
        {
            desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);

            SolidBrush b = new SolidBrush(Color.FromArgb(80, 255, 0, 0));

            Rect rect = new Rect();
            GetWindowRect(new IntPtr(Int32.Parse(tvChildHwnd.SelectedNode.Text.Split("  ")[0])), ref rect);


            g.FillRectangle(b, new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top));

            //g.Dispose();
            //ReleaseDC(IntPtr.Zero, desktopPtr);
        }
        private void lvSaveList_DoubleClick(object sender, EventArgs e)
        {
            if (lvSaveList.SelectedItems.Count > 0)
            {
                txtCaption.Text = lvSaveList.SelectedItems[0].SubItems[2].Text;
            }
        }
        private void lvCommands_DoubleClick(object sender, EventArgs e)
        {
            IntPtr hwnd = SelectActiveHandle();

            if (lvCommands.SelectedItems.Count > 0)
            {
                string command = lvCommands.SelectedItems[0].SubItems[0].Text;
                string[] dictKeys = itemDict.Keys.ToArray();
                switch (Array.IndexOf(dictKeys, command))
                {
                    case 0:// "SetForegroundWindow"
                        SetForegroundWindow(hwnd);
                        break;
                    case 1: // "WM_CLOSE"
                        PostMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                        break;
                    case 2: // "SC_MINIMIZE"
                        PostMessage(hwnd, WM_SYSCOMMAND, new IntPtr(SC_MINIMIZE), IntPtr.Zero);
                        break;
                    case 3: // "SW_HIDE"
                        ShowWindow(hwnd, SW_HIDE);
                        break;
                }
                command = null;
                dictKeys = null;
            }
            IntPtr SelectActiveHandle()
            {
                if (tvChildHwnd.SelectedNode != null)
                {
                    return new IntPtr(Int32.Parse(tvChildHwnd.SelectedNode.Text.Split("  ")[0]));
                }
                else
                {
                    return new IntPtr(Int32.Parse(txtHwndId.Text));
                }
            }
            hwnd = IntPtr.Zero;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //Task.Run(new Action(async () =>
            //{
            //    while (true)
            //    {
            //        this.BeginInvoke(new Action(() =>
            //        {
            //            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            //        }));
            //        await Task.Delay(100);
            //    }
            //}));
            Rect rect = new Rect();
            GetWindowRect(new IntPtr(Int32.Parse(txtHwndId.Text)), ref rect);
            txtCommander.AppendText(string.Format($"{rect.Top}/{rect.Left}/{rect.Bottom}/{rect.Right}" + Environment.NewLine));
            txtCommander.AppendText(string.Format($"{rect.Bottom - rect.Top}/{rect.Right - rect.Left}" + Environment.NewLine));
        }
    }
}
