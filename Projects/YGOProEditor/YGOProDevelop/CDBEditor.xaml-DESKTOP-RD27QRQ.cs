using Builder;
using Cfg;
using System;
using System.Collections.Generic;
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

        public void CreaetNew() {
            CDBManager.Instance.Add()
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            //考虑写一个 datas <=> CardBuilder 的Converter 来绑定DataContext到 lbxCard的SelectedItem，这样就好处理多。
            CardBuilder cb = new CardBuilder(lbxCard.SelectedItem as datas);
            this.DataContext = cb;

            if (lbxSubType != null) {
                switch (lbxSubType.SelectionMode) {

                    case SelectionMode.Multiple:
                        lbxSubType.SelectedItems.Clear();
                        foreach (object item in cb.Type.SubTypeItems) {
                            lbxSubType.SelectedItems.Add(item);
                        }
                        break;
                    case SelectionMode.Single:
                        lbxSubType.SelectedItem = cb.Type.SubTypeItems.FirstOrDefault();
                        break;
                }
            }

            if (lbxCategory != null) {
                lbxCategory.SelectedItems.Clear();
                foreach (object item in cb.Category.CategoryItems) {
                    lbxCategory.SelectedItems.Add(item);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            CardBuilder cb = this.DataContext as CardBuilder;
            MessageBox.Show(cb.Race.RaceItem.Description);
        }
    }

}
