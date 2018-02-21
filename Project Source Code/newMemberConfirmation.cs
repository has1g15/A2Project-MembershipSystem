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
 public partial class New_Member_Confirmation : Form
 {
 public New_Member_Confirmation()
 {
 InitializeComponent();
 }

 int membnum;
 private New_Member nm;

 //Gets the value from the method on the previous form
 private void getnewnumber()
 {
 membnum = nm.generatemembnumber();
 }
 //Label written when form loadsand generated membership number is written to
text box
 private void New_Member_Confirmation_Load(object sender, EventArgs e)
 {
 ConfirmMessage.Text = "Your details have been added to our\r\nrecords. In
the box below, a unique eight\r\ndigit nmembership number has been\r\ngenerated. You
will need to enter a password\r\nin the password box for your account and\r\nthen
click the submit button. You will then\r\nbe able to login to your account.";
 MembershipNumber.Text = Convert.ToString(membnum);

 }
 //Password encrypted before added to database
 private string encryptpass()
 {
 string pass = PasswordChoice.Text;
 char [] letter = new char[10];
 int[] x = new int[10];
 for (int i = 0; i <= pass.Length; i++)
 {

 letter[i] = Convert.ToChar(pass.Substring(i, i + 1));
 x[i] = (int)letter[i];
 x[i] = x[i] + 4;
 if ((x[i] > 122) && (x[i] < 127))
 {
 x[i] = 97 + (x[i] - 123);

 }
 }
 return pass;

 }
 //Password added to database when submit password button is clicked by user
 private void SubmitPass_Click(object sender, EventArgs e)
 {
 string pass = encryptpass();
 memberDataContext context = new memberDataContext();
 Member m = new Member
 {
 Password = pass
 };

 }
 }
}