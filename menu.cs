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
public partial class Menu : Form
 {
 public Menu()
 {
 InitializeComponent();
 }

 private void PurchaseTickets_Click(object sender, EventArgs e)
 {
 this.Hide();
 Ticket_Purchase tickets = new Ticket_Purchase();
 tickets.Closed += (s, args) => this.Close();
 tickets.Show();
 }
 //Opens form for user to purchase tickets
 private void PlanAwayRoute_Click(object sender, EventArgs e)
 {
 this.Hide();
 Route route = new Route();
 route.Closed += (s, args) => this.Close();
 route.Show();
 }
 //Opens form for user to plan route to away game
 private void EmailClub_Click(object sender, EventArgs e)
 {
 this.Hide();
 Email_Page mail = new Email_Page();
 mail.Closed += (s, args) => this.Close();
 mail.Show();
 }
 //Opens form for user to send an e-mail
 private void Logout_Click(object sender, EventArgs e)
 {
 this.Hide();
 Home_Screen home = new Home_Screen();
 home.Closed += (s, args) => this.Close();
 home.Show();
 }
 //Sends user back to home screen
 }