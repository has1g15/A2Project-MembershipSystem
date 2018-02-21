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
 public partial class Home_Screen : Form
 {
 public Home_Screen()
 {
 InitializeComponent();
 }
//Algorithm encrypting password
 private string encryptpass()
 {
 string pass = passwordTextBox.Text;
 char[] letter = new char[10];
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
//Checks that the membership number entered by the member

 {
 person.Membership_No = membnum;
 }
 return true;
 }
 //Checks that the password entered by the member exists in the members table
of the database
 private bool acceptmpass()
 {
 memberDataContext context = new memberDataContext();
 var peopledata =
 from person in context.Members
 where person.Password == passwordTextBox.Text
select new { person.Password };
 foreach (var person in context.Members)
 {
 person.Password = passwordTextBox.Text;
 }
 return true;
 }

 //Checks that the login number entered by a staff member exists in the
personnel table of the database
 private bool acceptplogin()
 {
 int loginno = Convert.ToInt32(membership_NoTextBox.Text);
 PersonnelDataContext context = new PersonnelDataContext();
 var peopledata =
 from person in context.Personnels
 where person.Login_No == loginno
 select new { person.Login_No };
 foreach (var person in context.Personnels)
 {
 person.Login_No = loginno;
 }

 return true;
 }
 //Checks that the password entered by a staff member exists in the personnel
table of the database
 private bool acceptppass()
 {
 PersonnelDataContext context = new PersonnelDataContext();
 var peopledata =
 from person in context.Personnels
 where person.Password == passwordTextBox.Text
 select new { person.Password };
 foreach (var person in context.Personnels)
 {
 person.Password = passwordTextBox.Text;
 }
 return true;
 }

 private void Logon_Click(object sender, EventArgs e)
 {
 //Boolean varaibles taking the return values of the functions of the user
entering data
 bool acptmembnum = acceptmno();
 bool acptmempass = acceptmpass();
 bool acptstafflog = acceptplogin();
 bool acptstaffpass = acceptppass();

 int membnum = Convert.ToInt32(membership_NoTextBox.Text);


 //Checks there is data present in the membership number text box
 if (membership_NoTextBox.Text == " ")
 {
 MessageBox.Show("Please enter your membership number");
 }
 else
 //Checks there is data present in the password text box
if (passwordTextBox.Text == " ")
 {
 MessageBox.Show("Please enter your password");
 }
else
 //Checks that the number entered is the correct length
 if ((membership_NoTextBox.Text.Length) > 8)
 {
 MessageBox.Show("Please ensure your membership number or
login number has the correct number of digits");
 }
 else
 if ((membership_NoTextBox.Text.Length) < 7)
{
 MessageBox.Show("Please ensure your membership number
or login number has the correct number of digits");
 }
else
 //If data is in a valid format and the appropriate
boolean variables are true then the relevant form is opened
 //Error messages are shown depending on whether the
data is recognised from the database
 if (acptmembnum == true)
 {
 if (acptmempass == true)
 {
 this.Hide();
Menu menu = new Menu();
 menu.Closed += (s, args) => this.Close();
menu.Show();
}

 else
{
 MessageBox.Show("The password entered is not recognised for
this account");
 }
 }
 else
 {
 MessageBox.Show("The membership number entered is not
recognised");
 }

 if(acptstafflog == true)
 {
 if (acptstaffpass == true)

 {
this.Hide();
Personnel_Control_Form staff = new Personnel_Control_Form();
 staff.Closed += (s, args) => this.Close();
 staff.Show();
}
else
{
 MessageBox.Show("The password entered is not recognised for
this account");
 }
 }
 else
 {
 MessageBox.Show("The login number entered is not recognised");
 }

 }
//When a new member clicks the new member button, the form opens
 private void NewMember_Click(object sender, EventArgs e)
 {
 this.Hide();
 New_Member newmemb = new New_Member();
 newmemb.Closed += (s, args) => this.Close();
 newmemb.Show();
 }