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
 public partial class Personnel_Control_Form : Form
 {
 public Personnel_Control_Form()
 {
 InitializeComponent();
 }
 private void membersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
 {
 this.Validate();
 this.membersBindingSource.EndEdit();
 this.tableAdapterManager.UpdateAll(this.membersDataSet);
 }
//Algorithm encrypting password
 private string encryptpass()
 {
 string pass = password.Text;
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
//Method checking there is data in all the text boxes and returning false if there
isn't
private bool checkdatapresent()
 {
 bool presentdata = false;
 if (MembNumber.Text == " ")
 {
 MessageBox.Show("Please enter membership number of member");
 }

 else
 if (password.Text == " ")
 {
 MessageBox.Show("Please enter a password for member");
 }
 else
 if (fName.Text == " ")
 {
 MessageBox.Show("Please enter your first name");
 }
 else
 if (sName.Text == " ")
 {
 MessageBox.Show("Please enter your surname");
 }
 else
 if (address.Text == " ")
 {
 MessageBox.Show("Please enter your address");
 }
else
 if (postcode.Text == " ")
 {
 MessageBox.Show("Please enter your postcode");
 }
else
{
 presentdata = true;
 }
 return presentdata;
 }
//Checks the membership number is the right length
 private bool checkmembnumber()
 {
 bool length = false;
 if (MembNumber.Text.Length == 8)
 {
 length = true;
 }
 return length;
 }
//Checks there are no alpha characters in the membership number entered
 private bool checkalphainname()
 {
 bool IsAlpha = true;
 foreach (char c in MembNumber.Text)
 {
 if (!Char.IsNumber(c))
 {
 IsAlpha = false;
break;
 }
 }
 return IsAlpha;
 }
//Checks that the first name and surname that have been entered don't contain any
numbers

 private bool checknumericinname()
 {
 bool IsNumeric = true;
 foreach (char c in fName.Text)
 {
 if (!Char.IsNumber(c))
 {
 IsNumeric = false;
break;
 }
 }
 foreach (char d in sName.Text)
 {
 if (!Char.IsNumber(d))
 {
 IsNumeric = false;
break;
 }
 }
 return IsNumeric;
 }
//Checks the postcode is the correct length
 private bool validatepclength()
 {
 bool length = false;
 if (postcode.Text.Length == 7)
 {
 length = true;
 }
 return length;
 }
//Boolean variables taking values of validation methods
 private void AddMember_Click(object sender, EventArgs e)
 {
 //Boolean variables taking values of validation methods
 bool datapresent = checkdatapresent();
 bool membnumberlength = checkmembnumber();
 bool presentnumeric = checknumericinname();
 bool validpc = validatepclength();
 //If the membership number length is not right, there is an error message
 if (membnumberlength == false)
 {
 MessageBox.Show("Ensure the membership number entered is 8
characters")
 }
 else
 //If there are numbers in the names, there is an error
 if (presentnumeric == true)
 {
 MessageBox.Show("Ensure the name entered contains no numeric
characters");
 }
 else
 //If the postcode is the wrong length, there is an error
 if (validpc == false)
 MessageBox.Show("Ensure the postcode is the correct number of
characters");
 }
 else
 //If data entered is valid, the member is added to the members
table
 {
 memberDataContext context = new memberDataContext();
 Member m = new Member
 {
 FName = fName.Text,
SName = sName.Text,
Address = address.Text,
Postcode = postcode.Text
 };
 context.Members.InsertOnSubmit(m);
 try
{
 context.SubmitChanges();
 }
 //There is an exception if the data can't be added
 catch (Exception e1)
 {
 Console.WriteLine(e1);
context.SubmitChanges();
 }
 }
 }
private void DeleteMember_Click(object sender, EventArgs e)
 {
 bool membnumberlength = checkmembnumber();
 bool alphamember = checkalphainname();
 int membnum = Convert.ToInt32(MembNumber.Text);
 //Checks the membership number entered is the right length
 if (membnumberlength == false)
 {
 MessageBox.Show("Ensure the membership number entered is 8
characters");
 }
 else
 //Checks the membership number has no letters in it
 if (alphamember == true)
 {
 MessageBox.Show("Ensure the membership number entered onlyt
contains numeric characters");
 }
 else
 //Finds membership number in database and deletes member
 {
 memberDataContext context = new memberDataContext();
 var peopledata =
 from person in context.Members
 where person.Membership_No == membnum
select person;

 foreach (var member in peopledata)
 {
 context.Members.DeleteOnSubmit(member);
 }
 try
{
 context.SubmitChanges();
 }
 //Exception if member is not deleted from the table
 catch (Exception e1)
 {
 Console.WriteLine(e1);
 }
 }
 }
/The details of a member can be overwritten when the member needs to change them
 private void EditMember_Click(object sender, EventArgs e)
 {
 int membnum = Convert.ToInt32(MembNumber.Text);
 memberDataContext context = new memberDataContext();
 var editpeople =
 from person in context.Members
 where person.Membership_No == membnum
 select person;
 foreach (Member person in editpeople)
 {
 person.Membership_No = membnum;
person.Password = password.Text;
person.FName = fName.Text;
person.SName = sName.Text;
person.Address = address.Text;
person.Postcode = postcode.Text;
 }
 try
 {
 context.SubmitChanges();
 }
 catch (Exception e1)
 {
 Console.WriteLine(e1);
 }
 }
//A member can be searched for and their details are displayed in the text boxes on
the form
 private void SearchMember_Click(object sender, EventArgs e)
 {
 int membnum = Convert.ToInt32(MembNumber.Text);
 memberDataContext context = new memberDataContext();
 var peopledata =
 from person in context.Members
 where person.Membership_No == membnum

 select person;
 foreach (var person in peopledata)
 {
 person.Membership_No = membnum;
 person.Password = password.Text;
 person.FName = fName.Text;
 person.SName = sName.Text;
 person.Address = address.Text;
 person.Postcode = postcode.Text;
 }

 }
 private void Logout_Click(object sender, EventArgs e)
 {
 this.Hide();
 Home_Screen home = new Home_Screen();
 home.FormClosed += (s, args) => this.Close();
 home.Show();
 }
 }
}