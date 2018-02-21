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
 public partial class New_Member : Form
 {
 public New_Member()
 {
 InitializeComponent();
 }
 //Checks that data has been entered into every box
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
 if (addressTextBox.Text == " ")
 {
 MessageBox.Show("Please enter your address");
 }
else
 if (postcodeTextBox.Text == " ")
 {
 MessageBox.Show("Please enter your postcode");
 }
else
{
 presentdata = true;
 }
 return presentdata;
 }
 //Checks that the names entered in the first name and surname boxes contain no
numeric characters
 private bool checknumericinname()
 {

 bool IsNumeric = true;
 foreach (char c in fNameTextBox.Text)
 {
 if (!Char.IsNumber(c))
 {

 IsNumeric = false;
break;
 }
 }
 foreach (char d in sNameTextBox.Text)
 {
 if (!Char.IsNumber(d))
 {
 IsNumeric = false;
break;
 }
 }
 return IsNumeric;
 }
 //Checks the postcode entered by the user has the correct number of characters
 private bool validatepclength()
 {
 bool length = false;
 if (postcodeTextBox.Text.Length == 7)
 {
 length = true;
 }
 return length;
 }
//New membership number generated for new member
 public int generatemembnumber()
 {
 int maxnumber = 0;
 int newnumb;
 memberDataContext context = new memberDataContext();
 var peopledata =
 from person in context.Members
 where person.Membership_No == maxnumber
 select new { person.Membership_No };

 foreach (var person in context.Members)
 {
 if (person.Membership_No > maxnumber)
 {
 person.Membership_No = maxnumber;
 }
 }
 newnumb = maxnumber + 1;
 return newnumb;
 }
 private void Submit_Click(object sender, EventArgs e)
 {
 bool datapresent = checkdatapresent();
 bool presentnumeric = checknumericinname();
 bool validpc = validatepclength();

 //If the method checking for numeric characters returns true, there is an
error
 if (presentnumeric == true)
 {
 MessageBox.Show("Ensure your name contains no numeric characters");

 }
 else
 if (validpc == false)
 {
 MessageBox.Show("Ensure your postcode is the correct number of
characters");
 }
 else
 {
 //When data is valid, details of user are added to data set
 memberDataContext context = new memberDataContext();
 Member m = new Member
 {
 Membership_No = generatemembnumber(),
 FName = fNameTextBox.Text,
SName = sNameTextBox.Text,
Address = addressTextBox.Text,
Postcode = postcodeTextBox.Text
 };
 context.Members.InsertOnSubmit(m);
 try
{
 context.SubmitChanges();
 }
catch (Exception e1)
 {
 Console.WriteLine(e1);
context.SubmitChanges();
 }
 //Once the user details have been added, the new member receives a
confirmation
 this.Hide();
New_Member_Confirmation confirm = new
New_Member_Confirmation();
 confirm.Closed += (s, args) => this.Close();
confirm.Show();

 }
 private void membersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
 {
 this.Validate();
 this.membersBindingSource.EndEdit();
 this.tableAdapterManager.UpdateAll(this.membersDataSet);
 }
//Takes user back to home screen
 private void Back_Click(object sender, EventArgs e)
 {
 this.Hide();
 Home_Screen home = new Home_Screen();
 home.Closed += (s, args) => this.Close();
 home.Show();
 }