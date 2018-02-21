using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Membership
{
 public partial class Ticket_Purchase : Form
 {
 public Ticket_Purchase()
 {
 InitializeComponent();
 }
 //Combo boxes on form are populated with quantity options
 private void Ticket_Purchase_Load(object sender, EventArgs e)
 {
 MembersTicket.Items.Add("0");
 MembersTicket.Items.Add("1");
 MembersTicket.Items.Add("2");
 MembersTicket.Items.Add("3");
 MembersTicket.Items.Add("4");
 MembersTicket.Items.Add("5");
-170-
Hannah Short Football Club Membership System
 if (AdultTicket.SelectedIndex > -1)
 {
 selected = true;
 }
 return selected;
 }
 //Checks to see if a quantity has been selected in the under 18 menu
 private bool checku18selected()
 {
 bool selected = false;
 if (U18Ticket.SelectedIndex > -1)
 {
 selected = true;
 }
 return selected;
 }
 //Gets the number of member tickets the member wants to purchase
 public int getmemberquantity()
 {
 int quantity = Convert.ToInt32(MembersTicket.SelectedValue);
 return quantity;
 }
 //Gets the number of adult tickets the member wants to purchase
 public int getadultquantity()
 {
 int quantity = Convert.ToInt32(AdultTicket.SelectedValue);
 return quantity;
 }
 //Gets the number of U18 tickets the member wants to purchase
 public int getu18quantity()
 {
 int quantity = Convert.ToInt32(U18Ticket.SelectedValue);
 return quantity;
 }
 //Calculates the total cost of the purchase for the member
 public int CalcCost()
 {
 int adultquantity = getadultquantity();
 int membersquantity = getmemberquantity();
 int totalcost;
 totalcost = ((adultquantity * 9) + (membersquantity * 5));
 return totalcost;
 }
 //Method writing the PayPal html file
 private void writepayhtml()
 {
 int totalcost = CalcCost();
 string[] htmllines = { "<form action=\"https//www.sandbox.paypal.com/cgibin/webscr\"
method=\"post>",
 " ",
"<input type=\"hidden\" name=\"cmd\"
value=\"_xclick\" />",
 "<input type=\"hidden\" name=\"business\"
value=\"hannah.short1@btinternet.com\" />",
 " ",
-171-
Hannah Short Football Club Membership System
 "<input type=\"hidden\" name=\"item_name\"
value=\"Total Cost\" />",
 "<input type=\"hidden\" name=\"amount\" value=\"" +
totalcost + "\" /> ",
 "<input type=\"hidden\" name=\"currency_code\"
value=\"GBP\">",
 "<input type=\"submit\" value=\"Buy\" />",
 " ",
"</form>"
 };

System.IO.File.WriteAllLines(@"C:\Users\\Owner\Documents\College\Computing\pay.html ",
htmllines);
 }
 private void Pay_Click(object sender, EventArgs e)
 {
 bool memberselect = checkmembersselected();
 bool adultselect = checkadultselected();
 bool u18select = checku18selected();
 if (memberselect == false)
 {
 MessageBox.Show("Please select a quantity of member tickets");
 }
 else
 if (adultselect == false)
 {
 MessageBox.Show("Please select a quantity of adult tickets");
 }
 else
 if (u18select == false)
 {
 MessageBox.Show("Please select a quantiy of under 18
tickets");
 }
else
{
 writepayhtml();
System.Diagnostics.Process.Start("h:/Computing/Unit
4/pay.html");
 this.Hide();
Ticket_Confirmation tconfirm = new Ticket_Confirmation();
 tconfirm.FormClosed += (s, args) => this.Close();
tconfirm.Show();
 }
 }
 private void Logout_Click(object sender, EventArgs e)
 {
 this.Hide();
 Home_Screen home = new Home_Screen();
 home.FormClosed += (s, args) => this.Close();
 home.Show();
 }
 private void Back_Click(object sender, EventArgs e)
 {
 this.Hide();
 Menu menu = new Menu();

 menu.FormClosed += (s, args) => this.Close();
 menu.Show();
 }

 }
}