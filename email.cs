using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Membership
{
 public partial class Email_Page : Form
 {
 public Email_Page()
 {
 InitializeComponent();
 }
//Checks that all the text boxes are full
 private bool checkdatapresent()
 {
 bool presentdata = false;
 if (fNameTextBox.Text == " ")
 {
 MessageBox.Show("Please enter your first name");
 }
 else
 if (sNameTextBox.Text == " ")
 {
 MessageBox.Show("Please enter your surname");
 }
 else
 if (phonetextBox.Text == " ")
 {
 MessageBox.Show("Please enter a phone number");
 }
else
 if (addresstextBox.Text == " ")
 {
 MessageBox.Show("Please enter your e-mail

 return presentdata;
 }
 //Checks there are no alpha characters in the phone number
 private bool checkalphanumber()
 {
 bool IsAlpha = false;
 foreach (char c in phonetextBox.Text)
 {
 if (!Char.IsNumber(c))
 {
 IsAlpha = true;
break;
 }
 }

 return IsAlpha;
 }
 //Checks the range of the subject
 private bool checksubjectlength()
 {
 bool length = false;
 if (subjecttextBox.Text.Length <= 40)
 {
 length = true;
 }
 return length;
 }
 //Checks the range of the message
 private bool checkmessagelength()
 {
 bool mlength = false;
 if (messagetextBox.Text.Length <= 400)
 {
 mlength = true;
 }
 return mlength;
 }
 private void Send_Click(object sender, EventArgs e)
 {
 bool datapresent = checkdatapresent();
 bool presentalpha = checkalphanumber();
 bool validsubjectlength = checksubjectlength();
 bool validmessagelength = checkmessagelength();
 //If the checkalphanumber method finds letters in the phone number, an
error message is displayed
 if (presentalpha == true)
 {
 MessageBox.Show("Ensure your phone number contains only numeric
characters");
 }
 else
 //If the subject length is over 40 characters, there is an error
 if (validsubjectlength == false)
 {
 MessageBox.Show("Ensure your subject is less than 40 characters");
 }
 else

 if (validmessagelength == false)
 {
 MessageBox.Show("Ensure your message is less than 400
characters");
 }
else
//If all data is present, the e-mail gets sent using smtp protocol
if (datapresent == true)
 {
 try
 {
 //E-mail message constructed from data entered
MailMessage message = new MailMessage();
 message.To.Add("hannah.short1@btinternet.com");
 string mailaddress;
 mailaddress = addresstextBox.Text;
MailAddress address = new MailAddress(mailaddress);
 message.From = address;
string subject = subjecttextBox.Text;
message.Subject = subject;
string msg = messagetextBox.Text;
message.Body = msg;
 var smtp = new System.Net.Mail.SmtpClient();
 {
 smtp.Host = " ";
smtp.Port = 587;
smtp.EnableSsl = true;
smtp.DeliveryMethod =
System.Net.Mail.SmtpDeliveryMethod.Network;
 }
//An e-mail confirmation form comes up when the user has
clicked send
 this.Hide();
Emal_Confirmation confirm = new Emal_Confirmation();
 confirm.Closed += (s, args) => this.Close();
confirm.Show();
 }
 //If the message isn;t succesfully sent, there is a
default error message
 catch { MessageBox.Show("Error Sending E-mail, Please try
again"); }
 }

 }
 private void membersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
 {
 this.Validate();
 this.membersBindingSource.EndEdit();
 this.tableAdapterManager.UpdateAll(this.membersDataSet);
 }
 //Takes user back to home screen
 private void Logout_Click(object sender, EventArgs e)
 {
 this.Hide();
 Home_Screen home = new Home_Screen();
 home.FormClosed += (s, args) => this.Close();
 home.Show();
 }

 //Takes user back to menu
 private void Back_Click(object sender, EventArgs e)
 {
 this.Hide();
 Menu menu = new Menu();
 menu.FormClosed += (s, args) => this.Close();
 menu.Show();
 }
 }
 }