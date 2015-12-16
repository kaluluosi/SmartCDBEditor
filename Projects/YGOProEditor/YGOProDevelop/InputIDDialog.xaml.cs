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

namespace YGOProDevelop {
    /// <summary>
    /// InputIDDialog.xaml 的交互逻辑
    /// </summary>
    public partial class InputIDDialog : Window {
        public InputIDDialog() {
            InitializeComponent();
            ItemMonster.Tag = Builder.CardBuilder.CardType.Monster;
            ItemSpell.Tag = Builder.CardBuilder.CardType.Spell;
            ItemTrap.Tag = Builder.CardBuilder.CardType.Trap;
            this.DataContext = this;

            Binding binding = new Binding("ID");
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //IDIsExistedRule idIsExistedRule = new IDIsExistedRule();
            //idIsExistedRule.ValidatesOnTargetUpdated = true;
            //binding.ValidationRules.Add(idIsExistedRule);
            tbxID.SetBinding(TextBox.TextProperty, binding);
        }

        public int ID { get; set; }
        public Builder.CardBuilder.CardType Type { get; set; }

        private void btnOK_Click(object sender, RoutedEventArgs e) {
            Image img = lbxCardType.SelectedItem as Image;
            Type = (Builder.CardBuilder.CardType)img.Tag;
            if (Validation.GetHasError(tbxID)) {
                MessageBox.Show("ID冲突,重新输入");
                return;
            }
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }
    }
}
