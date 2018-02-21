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
 public partial class Route_Plan : Form
 {

 public Route_Plan()
 {
 InitializeComponent();

 }
 string club;
 private Route r;
 //A method getting the team name from the previous form
 private void getteam()
 {
 club = r.getselectedteam();
 }
 private void Route_Plan_Load(object sender, EventArgs e)
 {
 bool mileschecked = r.MilesSelected();
 bool kmchecked = r.KMSelected();
 //The club selected on the previous form is written into the first text
box on the form
 ClubName.Text = club;
 //If the miles option was selected on the previous form
 if (mileschecked == true)
 {
 string distance =
System.IO.File.ReadAllText(@"f:/Membership/DistanceMiles.txt");
 Distance.Text = distance;
 }
 else
 if (kmchecked == true)
 {
 string distance =
System.IO.File.ReadAllText(@"f:/Membership/DistanceKM.txt");
 Distance.Text = distance;
 }
 string direction = System.IO.File.ReadAllText(@"f:/Membership/Directions
.txt");
 Direction.Text = direction;

 
-182-
Hannah Short Football Club Membership System
 }
 private void Logout_Click(object sender, EventArgs e)
 {
 this.Hide();
 Home_Screen home = new Home_Screen();
 home.Closed += (s, args) => this.Close();
 home.Show();
 }
 private void Back_Click(object sender, EventArgs e)
 {
 this.Hide();
 Menu menu = new Menu();
 menu.Closed += (s, args) => this.Close();
 menu.Show();
 }
 private void Direction_TextChanged(object sender, EventArgs e)
 {
 Direction.ScrollBars = ScrollBars.Vertical;
 }
 private void Distance_TextChanged(object sender, EventArgs e)
 {
 Distance.ScrollBars = ScrollBars.Vertical;
 }


 }
}