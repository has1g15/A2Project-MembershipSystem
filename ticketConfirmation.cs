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
 public partial class Ticket_Confirmation : Form
 {
 public Ticket_Confirmation()
 {
 InitializeComponent();
 }
 int adultticket;
 int memberticket;
 int u18ticket;
 private Ticket_Purchase tp;
 //Gets the ticket quantities selected on the previous form
 public void getticketquantities()
 {
 adultticket = tp.getadultquantity();
 memberticket = tp.getmemberquantity();
 u18ticket = tp.getu18quantity();
 }
 //The label confirming the tickets bought by the user is written when the form
loads
 private void Ticket_Confirmation_Load(object sender, EventArgs e)
 {
 TConfirm.Text = "Thank you for puchasing your tickets.\r\nYou have
purchased:\r\n" + adultticket + "adult tickets,\r\n" + memberticket + "members
tickets,\r\n" + u18ticket + "under 18 tickets";
 }
 }
}