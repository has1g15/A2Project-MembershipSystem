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
 public partial class Route : Form
 {
 public Route()
 {
 InitializeComponent();
 }
 //Combo box is populated with Ryman Youth league teams when form loads
 private void Route_Load(object sender, EventArgs e)
 {
 Teams.Items.Add("Bognor Regis Football Club");
 Teams.Items.Add("Eastbourne Borough Football Club");
 Teams.Items.Add("Eastbourne Town Football Club");
 Teams.Items.Add("Hastings United Football Club");
 Teams.Items.Add("Horsham Football Club");
 Teams.Items.Add("Lewes Football Club");
 Teams.Items.Add("Three Bridges Football Club");
 Teams.Items.Add("Whitehawk Football Club");
 Teams.Items.Add("Worthing Football Club");
 }
 //Gets the team the user has selected
 public string getselectedteam()
 {
 string club = Convert.ToString(Teams.SelectedValue);
 return club;
 }
 //Gets the corresponding node of the team on the
 node = 5;
break;
 case "Lewes Football Club":
 node = 6;
break;
 case "Three Bridges Football Club":
 node = 7;
break;
 case "Whitehawk Football Club":
 node = 8;
break;
 case "Worthing Football Club":
 node = 9;
break;
 default:
 node = 0;
break;
 }
 return node;
 }
 //Algorithm finding the node on the graph the member has selected
 private bool calcroute(int Node, int EndNode)
 {
 int[,] weights = new int[,]
 {
 {0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
 {1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
 };
 bool[] Found = new bool[30];
 bool[] DestinationReached = new bool[30];
 bool Reached = false;
 if (Node == EndNode)
 {
 Reached = true;
 }
 for (int i = 0; i < 30; i++)
 {
 if (Found[i] == false)
 {
 calcroute(Node, EndNode);
 }
 }
 DestinationReached[Node] = true;

 return DestinationReached[Node];
 }
 //Method checking if the miles checkbox has been checked
 public bool MilesSelected()
 {
 bool check = false;
 if (Miles.Checked == true)
 {
 check = true;
 }
 return check;
 }
 //Method checking if the kilometres checkbox has been checked
 public bool KMSelected()
 {
 bool check = false;
 if (KM.Checked == true)
 {
 check = true;
 }
 return check;
 }
 private void GetRoute_Click(object sender, EventArgs e)
 {
 bool milesselected = MilesSelected();
 bool kmselected = KMSelected();
 //An error is given if no team has been selected
 if (Teams.SelectedIndex <= -1)
 {
 MessageBox.Show("Please ensure you have selected a team");
 }
 else
 //An error is given if neither the miles or kilometres options have
been selected
 if ((milesselected = false) && (kmselected == false))
 {
 MessageBox.Show("Please check you have selected if you want your
journey to be displayed in miles or kilometres");
 }
 else
 //An error is given if both options have been selected
 if ((milesselected = true) && (kmselected == true))
 {
 MessageBox.Show("Please check you have only selected one
distance option");
 }
else
 //If the options selected are valid, the route plan is loaded
 {
 this.Hide();
 Route_Plan r = new Route_Plan();
 r.Closed += (s, args) => this.Close();
 r.Show();
 }
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
 }
}