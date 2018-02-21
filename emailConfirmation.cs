using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Membership
{
 public partial class Emal_Confirmation : Form
 {
 public Emal_Confirmation()
 {
 InitializeComponent();
 }
 //The user is able to logout when they have read the confirmation message
 private void Logout_Click(object sender, EventArgs e)
 {
 this.Hide();
 Home_Screen home = new Home_Screen();
 home.FormClosed += (s, args) => this.Close();
 home.Show();
 }
 //When the confiramtion form loads, a label thanking the member is written
 private void Emal_Confirmation_Load(object sender, EventArgs e)
 {
 ConfirmMail.Text = "Thank you for your e-mail.\r\nWe will reply to you
shortly";
 }
 }
}