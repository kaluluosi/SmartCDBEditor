using Builder;
using Cfg;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YGOProDevelop.CDB;

namespace YGOProDevelop {

    /// <summary>
    /// CDBEditor.xaml 的交互逻辑
    /// </summary>
    public partial class CDBEditor : Window {
        public CDBEditor() {
            InitializeComponent();
            lbxCard.SelectedIndex = 0;
        }

        public CardBuilder CardBdr { get; set; }

        /// <summary>
        /// 提交修改
        /// </summary>
        public void Submit() {
            datas source = lbxCard.SelectedItem as datas;
            CardBdr.Type.SubTypeItems.Clear();
            foreach (VarItem item in lbxSubType.SelectedItems) {
                CardBdr.Type.SubTypeItems.Add(item);
            }

            CardBdr.Category.CategoryItems.Clear();
            foreach (VarItem item in lbxCategory.SelectedItems) {
                CardBdr.Category.CategoryItems.Add(item);
            }

            CardBdr.CopyTo(source);
            MessageBox.Show(this, "保存成功!");

        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if (lbxCard.SelectedItem == null) return;
            //考虑写一个 datas <=> CardBuilder 的Converter 来绑定DataContext到 lbxCard的SelectedItem，这样就好处理多。
            CardBdr = new CardBuilder(lbxCard.SelectedItem as datas);
            this.DataContext = CardBdr;

            if (lbxSubType != null) {
                switch (lbxSubType.SelectionMode) {

                    case SelectionMode.Multiple:
                        lbxSubType.SelectedItems.Clear();
                        foreach (object item in CardBdr.Type.SubTypeItems) {
                            lbxSubType.SelectedItems.Add(item);
                        }
                        break;
                    case SelectionMode.Single:
                        if (CardBdr.Type.SubTypeItems != null)
                            lbxSubType.SelectedItem = CardBdr.Type.SubTypeItems.FirstOrDefault();
                        break;
                }
            }

            if (lbxCategory != null) {
                lbxCategory.SelectedItems.Clear();
                foreach (object item in CardBdr.Category.CategoryItems) {
                    lbxCategory.SelectedItems.Add(item);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            int index = lbxCard.SelectedIndex;
            CDBManager.Instance.Remove(lbxCard.SelectedItem as datas);
            lbxCard.SelectedIndex = index;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            Submit();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e) {

            InputIDDialog inputIDDlg = new InputIDDialog();
            
            if(inputIDDlg.ShowDialog() == true) {
                datas d = CardBuilder.CreateDefaultData(inputIDDlg.Type);
                d.id = inputIDDlg.ID;
                d.texts.id = inputIDDlg.ID;
                CDBManager.Instance.Add(d);
                lbxCard.SelectedItem = d;
                lbxCard.ScrollIntoView(d);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) {
            string keyword = tbxSearchCondition.Text;

            if (string.IsNullOrEmpty(keyword)) {
                CDBManager.Instance.ResetSearch();
                return;
            }

            int id = 0;
            if (int.TryParse(keyword, out id) == true) {
                CDBManager.Instance.Search(id);
            }
            else {
                CDBManager.Instance.Search(keyword);
            }
        }

        private void btnSaveAll_Click(object sender, RoutedEventArgs e) {
           int count = CDBManager.Instance.Save();
            MessageBox.Show("保存了 " + count + "条");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "CDB数据库文件|*.cdb";
            bool? result = openFileDlg.ShowDialog();
            if(result == true) {
                CDBManager.Instance.Open(openFileDlg.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) {
            datas card = lbxCard.SelectedItem as datas;
            string filePath = "script/c" + card.id + ".lua";
            if(File.Exists(filePath) == false)
                MessageBox.Show("脚本不存在!");
            try {
                Process.Start("everedit.exe", filePath);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) {
            MessageBox.Show("如果对这个cdb编辑器有新建议，请随便邮件给我，我必定会答复的并采纳改进的！我的邮箱是kaluluosi111@qq.com。","反馈建议");
        }
    }

}
