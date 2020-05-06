using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace BattleShipClient
{
    public partial class Form1 : Form
    {
        //Opretter spillepladerne
        Spilleplade[,] spilleplade1 = new Spilleplade[10, 10];
        Spilleplade[,] spilleplade2 = new Spilleplade[10, 10];

        //
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;

        private Spilleplade valgtKnap;

        bool hangarskib = false;
        bool krysser = false;
        bool detroyer = false;
        bool patrule = false;
        bool Ubåd = false;
        bool rotaion = false;
        bool turn = true;
        int hangarskibAntal = 0;
        int krysserAntal = 0;
        int detroyerAntal = 0;
        int patruleAntal = 0;
        int ubådAntal = 0;




        public Form1()
        {
            InitializeComponent();
            //tableLayoutPanel1.Visible = false;
            btnHangaskib.Visible = false;
            btnKrysser.Visible = false;
            btnDestroyer.Visible = false;
            btnPatrule.Visible = false;
            btnUbåd.Visible =   false;
            btnRoation.Visible = false;
            lblRotation.Visible =   false;
            BtnPlaceingGodkendt.Visible = false;
            BtnPlacerIgen.Visible = false;
            tableLayoutPanel1.Enabled = false;
            lblSkibe.Visible = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //readData = "Conected to Chat Server ...";
            //msg();
            //clientSocket.Connect("192.168.0.103", 8888);
            //serverStream = clientSocket.GetStream();



            //spillerens spilleplade
            spilleplade1[0, 0] = new Spilleplade(btn1A1, ' ', 1);
            spilleplade1[0, 1] = new Spilleplade(btn1A2, ' ', 2);
            spilleplade1[0, 2] = new Spilleplade(btn1A3, ' ', 3);
            spilleplade1[0, 3] = new Spilleplade(btn1A4, ' ', 4);
            spilleplade1[0, 4] = new Spilleplade(btn1A5, ' ', 5);
            spilleplade1[0, 5] = new Spilleplade(btn1A6, ' ', 6);
            spilleplade1[0, 6] = new Spilleplade(btn1A7, ' ', 7);
            spilleplade1[0, 7] = new Spilleplade(btn1A8, ' ', 8);
            spilleplade1[0, 8] = new Spilleplade(btn1A9, ' ', 9);
            spilleplade1[0, 9] = new Spilleplade(btn1A10, ' ', 10);
            spilleplade1[1, 0] = new Spilleplade(btn1B1, ' ', 11);
            spilleplade1[1, 1] = new Spilleplade(btn1B2, ' ', 12);
            spilleplade1[1, 2] = new Spilleplade(btn1B3, ' ', 13);
            spilleplade1[1, 3] = new Spilleplade(btn1B4, ' ', 14);
            spilleplade1[1, 4] = new Spilleplade(btn1B5, ' ', 15);
            spilleplade1[1, 5] = new Spilleplade(btn1B6, ' ', 16);
            spilleplade1[1, 6] = new Spilleplade(btn1B7, ' ', 17);
            spilleplade1[1, 7] = new Spilleplade(btn1B8, ' ', 18);
            spilleplade1[1, 8] = new Spilleplade(btn1B9, ' ', 19);
            spilleplade1[1, 9] = new Spilleplade(btn1B10, ' ', 20);
            spilleplade1[2, 0] = new Spilleplade(btn1C1, ' ', 21);
            spilleplade1[2, 1] = new Spilleplade(btn1C2, ' ', 22);
            spilleplade1[2, 2] = new Spilleplade(btn1C3, ' ', 23);
            spilleplade1[2, 3] = new Spilleplade(btn1C4, ' ', 24);
            spilleplade1[2, 4] = new Spilleplade(btn1C5, ' ', 25);
            spilleplade1[2, 5] = new Spilleplade(btn1C6, ' ', 26);
            spilleplade1[2, 6] = new Spilleplade(btn1C7, ' ', 27);
            spilleplade1[2, 7] = new Spilleplade(btn1C8, ' ', 28);
            spilleplade1[2, 8] = new Spilleplade(btn1C9, ' ', 29);
            spilleplade1[2, 9] = new Spilleplade(btn1C10, ' ', 30);
            spilleplade1[3, 0] = new Spilleplade(btn1D1, ' ', 31);
            spilleplade1[3, 1] = new Spilleplade(btn1D2, ' ', 32);
            spilleplade1[3, 2] = new Spilleplade(btn1D3, ' ', 33);
            spilleplade1[3, 3] = new Spilleplade(btn1D4, ' ', 34);
            spilleplade1[3, 4] = new Spilleplade(btn1D5, ' ', 35);
            spilleplade1[3, 5] = new Spilleplade(btn1D6, ' ', 36);
            spilleplade1[3, 6] = new Spilleplade(btn1D7, ' ', 37);
            spilleplade1[3, 7] = new Spilleplade(btn1D8, ' ', 38);
            spilleplade1[3, 8] = new Spilleplade(btn1D9, ' ', 39);
            spilleplade1[3, 9] = new Spilleplade(btn1D10, ' ', 40);
            spilleplade1[4, 0] = new Spilleplade(btn1E1, ' ', 41);
            spilleplade1[4, 1] = new Spilleplade(btn1E2, ' ', 42);
            spilleplade1[4, 2] = new Spilleplade(btn1E3, ' ', 43);
            spilleplade1[4, 3] = new Spilleplade(btn1E4, ' ', 44);
            spilleplade1[4, 4] = new Spilleplade(btn1E5, ' ', 45);
            spilleplade1[4, 5] = new Spilleplade(btn1E6, ' ', 46);
            spilleplade1[4, 6] = new Spilleplade(btn1E7, ' ', 47);
            spilleplade1[4, 7] = new Spilleplade(btn1E8, ' ', 48);
            spilleplade1[4, 8] = new Spilleplade(btn1E9, ' ', 49);
            spilleplade1[4, 9] = new Spilleplade(btn1E10, ' ', 50);
            spilleplade1[5, 0] = new Spilleplade(btn1F1, ' ', 51);
            spilleplade1[5, 1] = new Spilleplade(btn1F2, ' ', 52);
            spilleplade1[5, 2] = new Spilleplade(btn1F3, ' ', 53);
            spilleplade1[5, 3] = new Spilleplade(btn1F4, ' ', 54);
            spilleplade1[5, 4] = new Spilleplade(btn1F5, ' ', 55);
            spilleplade1[5, 5] = new Spilleplade(btn1F6, ' ', 56);
            spilleplade1[5, 6] = new Spilleplade(btn1F7, ' ', 57);
            spilleplade1[5, 7] = new Spilleplade(btn1F8, ' ', 58);
            spilleplade1[5, 8] = new Spilleplade(btn1F9, ' ', 59);
            spilleplade1[5, 9] = new Spilleplade(btn1F10, ' ', 60);
            spilleplade1[6, 0] = new Spilleplade(btn1G1, ' ', 61);
            spilleplade1[6, 1] = new Spilleplade(btn1G2, ' ', 62);
            spilleplade1[6, 2] = new Spilleplade(btn1G3, ' ', 63);
            spilleplade1[6, 3] = new Spilleplade(btn1G4, ' ', 64);
            spilleplade1[6, 4] = new Spilleplade(btn1G5, ' ', 65);
            spilleplade1[6, 5] = new Spilleplade(btn1G6, ' ', 66);
            spilleplade1[6, 6] = new Spilleplade(btn1G7, ' ', 67);
            spilleplade1[6, 7] = new Spilleplade(btn1G8, ' ', 68);
            spilleplade1[6, 8] = new Spilleplade(btn1G9, ' ', 69);
            spilleplade1[6, 9] = new Spilleplade(btn1G10, ' ', 70);
            spilleplade1[7, 0] = new Spilleplade(btn1H1, ' ', 71);
            spilleplade1[7, 1] = new Spilleplade(btn1H2, ' ', 72);
            spilleplade1[7, 2] = new Spilleplade(btn1H3, ' ', 73);
            spilleplade1[7, 3] = new Spilleplade(btn1H4, ' ', 74);
            spilleplade1[7, 4] = new Spilleplade(btn1H5, ' ', 75);
            spilleplade1[7, 5] = new Spilleplade(btn1H6, ' ', 76);
            spilleplade1[7, 6] = new Spilleplade(btn1H7, ' ', 77);
            spilleplade1[7, 7] = new Spilleplade(btn1H8, ' ', 78);
            spilleplade1[7, 8] = new Spilleplade(btn1H9, ' ', 79);
            spilleplade1[7, 9] = new Spilleplade(btn1H10, ' ', 80);
            spilleplade1[8, 0] = new Spilleplade(btn1I1, ' ', 81);
            spilleplade1[8, 1] = new Spilleplade(btn1I2, ' ', 82);
            spilleplade1[8, 2] = new Spilleplade(btn1I3, ' ', 83);
            spilleplade1[8, 3] = new Spilleplade(btn1I4, ' ', 84);
            spilleplade1[8, 4] = new Spilleplade(btn1I5, ' ', 85);
            spilleplade1[8, 5] = new Spilleplade(btn1I6, ' ', 86);
            spilleplade1[8, 6] = new Spilleplade(btn1I7, ' ', 87);
            spilleplade1[8, 7] = new Spilleplade(btn1I8, ' ', 88);
            spilleplade1[8, 8] = new Spilleplade(btn1I9, ' ', 89);
            spilleplade1[8, 9] = new Spilleplade(btn1I10, ' ', 90);
            spilleplade1[9, 0] = new Spilleplade(btn1J1, ' ', 91);
            spilleplade1[9, 1] = new Spilleplade(btn1J2, ' ', 92);
            spilleplade1[9, 2] = new Spilleplade(btn1J3, ' ', 93);
            spilleplade1[9, 3] = new Spilleplade(btn1J4, ' ', 94);
            spilleplade1[9, 4] = new Spilleplade(btn1J5, ' ', 95);
            spilleplade1[9, 5] = new Spilleplade(btn1J6, ' ', 96);
            spilleplade1[9, 6] = new Spilleplade(btn1J7, ' ', 97);
            spilleplade1[9, 7] = new Spilleplade(btn1J8, ' ', 98);
            spilleplade1[9, 8] = new Spilleplade(btn1J9, ' ', 99);
            spilleplade1[9, 9] = new Spilleplade(btn1J10, ' ', 100);

            //Modstanderens spilleplade
            spilleplade2[0, 0] = new Spilleplade(btn2A1, ' ', 1);
            spilleplade2[0, 1] = new Spilleplade(btn2A2, ' ', 2);
            spilleplade2[0, 2] = new Spilleplade(btn2A3, ' ', 3);
            spilleplade2[0, 3] = new Spilleplade(btn2A4, ' ', 4);
            spilleplade2[0, 4] = new Spilleplade(btn2A5, ' ', 5);
            spilleplade2[0, 5] = new Spilleplade(btn2A6, ' ', 6);
            spilleplade2[0, 6] = new Spilleplade(btn2A7, ' ', 7);
            spilleplade2[0, 7] = new Spilleplade(btn2A8, ' ', 8);
            spilleplade2[0, 8] = new Spilleplade(btn2A9, ' ', 9);
            spilleplade2[0, 9] = new Spilleplade(btn2A10, ' ', 10);
            spilleplade2[1, 0] = new Spilleplade(btn2B1, ' ', 11);
            spilleplade2[1, 1] = new Spilleplade(btn2B2, ' ', 12);
            spilleplade2[1, 2] = new Spilleplade(btn2B3, ' ', 13);
            spilleplade2[1, 3] = new Spilleplade(btn2B4, ' ', 14);
            spilleplade2[1, 4] = new Spilleplade(btn2B5, ' ', 15);
            spilleplade2[1, 5] = new Spilleplade(btn2B6, ' ', 16);
            spilleplade2[1, 6] = new Spilleplade(btn2B7, ' ', 17);
            spilleplade2[1, 7] = new Spilleplade(btn2B8, ' ', 18);
            spilleplade2[1, 8] = new Spilleplade(btn2B9, ' ', 19);
            spilleplade2[1, 9] = new Spilleplade(btn2B10, ' ', 20);
            spilleplade2[2, 0] = new Spilleplade(btn2C1, ' ', 21);
            spilleplade2[2, 1] = new Spilleplade(btn2C2, ' ', 22);
            spilleplade2[2, 2] = new Spilleplade(btn2C3, ' ', 23);
            spilleplade2[2, 3] = new Spilleplade(btn2C4, ' ', 24);
            spilleplade2[2, 4] = new Spilleplade(btn2C5, ' ', 25);
            spilleplade2[2, 5] = new Spilleplade(btn2C6, ' ', 26);
            spilleplade2[2, 6] = new Spilleplade(btn2C7, ' ', 27);
            spilleplade2[2, 7] = new Spilleplade(btn2C8, ' ', 28);
            spilleplade2[2, 8] = new Spilleplade(btn2C9, ' ', 29);
            spilleplade2[2, 9] = new Spilleplade(btn2C10, ' ', 30);
            spilleplade2[3, 0] = new Spilleplade(btn2D1, ' ', 31);
            spilleplade2[3, 1] = new Spilleplade(btn2D2, ' ', 32);
            spilleplade2[3, 2] = new Spilleplade(btn2D3, ' ', 33);
            spilleplade2[3, 3] = new Spilleplade(btn2D4, ' ', 34);
            spilleplade2[3, 4] = new Spilleplade(btn2D5, ' ', 35);
            spilleplade2[3, 5] = new Spilleplade(btn2D6, ' ', 36);
            spilleplade2[3, 6] = new Spilleplade(btn2D7, ' ', 37);
            spilleplade2[3, 7] = new Spilleplade(btn2D8, ' ', 38);
            spilleplade2[3, 8] = new Spilleplade(btn2D9, ' ', 39);
            spilleplade2[3, 9] = new Spilleplade(btn2D10, ' ', 40);
            spilleplade2[4, 0] = new Spilleplade(btn2E1, ' ', 41);
            spilleplade2[4, 1] = new Spilleplade(btn2E2, ' ', 42);
            spilleplade2[4, 2] = new Spilleplade(btn2E3, ' ', 43);
            spilleplade2[4, 3] = new Spilleplade(btn2E4, ' ', 44);
            spilleplade2[4, 4] = new Spilleplade(btn2E5, ' ', 45);
            spilleplade2[4, 5] = new Spilleplade(btn2E6, ' ', 46);
            spilleplade2[4, 6] = new Spilleplade(btn2E7, ' ', 47);
            spilleplade2[4, 7] = new Spilleplade(btn2E8, ' ', 48);
            spilleplade2[4, 8] = new Spilleplade(btn2E9, ' ', 49);
            spilleplade2[4, 9] = new Spilleplade(btn2E10, ' ', 50);
            spilleplade2[5, 0] = new Spilleplade(btn2F1, ' ', 51);
            spilleplade2[5, 1] = new Spilleplade(btn2F2, ' ', 52);
            spilleplade2[5, 2] = new Spilleplade(btn2F3, ' ', 53);
            spilleplade2[5, 3] = new Spilleplade(btn2F4, ' ', 54);
            spilleplade2[5, 4] = new Spilleplade(btn2F5, ' ', 55);
            spilleplade2[5, 5] = new Spilleplade(btn2F6, ' ', 56);
            spilleplade2[5, 6] = new Spilleplade(btn2F7, ' ', 57);
            spilleplade2[5, 7] = new Spilleplade(btn2F8, ' ', 58);
            spilleplade2[5, 8] = new Spilleplade(btn2F9, ' ', 59);
            spilleplade2[5, 9] = new Spilleplade(btn2F10, ' ', 60);
            spilleplade2[6, 0] = new Spilleplade(btn2G1, ' ', 61);
            spilleplade2[6, 1] = new Spilleplade(btn2G2, ' ', 62);
            spilleplade2[6, 2] = new Spilleplade(btn2G3, ' ', 63);
            spilleplade2[6, 3] = new Spilleplade(btn2G4, ' ', 64);
            spilleplade2[6, 4] = new Spilleplade(btn2G5, ' ', 65);
            spilleplade2[6, 5] = new Spilleplade(btn2G6, ' ', 66);
            spilleplade2[6, 6] = new Spilleplade(btn2G7, ' ', 67);
            spilleplade2[6, 7] = new Spilleplade(btn2G8, ' ', 68);
            spilleplade2[6, 8] = new Spilleplade(btn2G9, ' ', 69);
            spilleplade2[6, 9] = new Spilleplade(btn2G10, ' ', 70);
            spilleplade2[7, 0] = new Spilleplade(btn2H1, ' ', 71);
            spilleplade2[7, 1] = new Spilleplade(btn2H2, ' ', 72);
            spilleplade2[7, 2] = new Spilleplade(btn2H3, ' ', 73);
            spilleplade2[7, 3] = new Spilleplade(btn2H4, ' ', 74);
            spilleplade2[7, 4] = new Spilleplade(btn2H5, ' ', 75);
            spilleplade2[7, 5] = new Spilleplade(btn2H6, ' ', 76);
            spilleplade2[7, 6] = new Spilleplade(btn2H8, ' ', 77);
            spilleplade2[7, 7] = new Spilleplade(btn2H8, ' ', 78);
            spilleplade2[7, 8] = new Spilleplade(btn2H9, ' ', 79);
            spilleplade2[7, 9] = new Spilleplade(btn2H10, ' ', 80);
            spilleplade2[8, 0] = new Spilleplade(btn2I1, ' ', 81);
            spilleplade2[8, 1] = new Spilleplade(btn2I2, ' ', 82);
            spilleplade2[8, 2] = new Spilleplade(btn2I3, ' ', 83);
            spilleplade2[8, 3] = new Spilleplade(btn2I4, ' ', 84);
            spilleplade2[8, 4] = new Spilleplade(btn2I5, ' ', 85);
            spilleplade2[8, 5] = new Spilleplade(btn2I6, ' ', 86);
            spilleplade2[8, 6] = new Spilleplade(btn2I7, ' ', 87);
            spilleplade2[8, 7] = new Spilleplade(btn2I8, ' ', 88);
            spilleplade2[8, 8] = new Spilleplade(btn2I9, ' ', 89);
            spilleplade2[8, 9] = new Spilleplade(btn2I10, ' ', 90);
            spilleplade2[9, 0] = new Spilleplade(btn2J1, ' ', 91);
            spilleplade2[9, 1] = new Spilleplade(btn2J2, ' ', 92);
            spilleplade2[9, 2] = new Spilleplade(btn2J3, ' ', 93);
            spilleplade2[9, 3] = new Spilleplade(btn2J4, ' ', 94);
            spilleplade2[9, 4] = new Spilleplade(btn2J5, ' ', 95);
            spilleplade2[9, 5] = new Spilleplade(btn2J6, ' ', 96);
            spilleplade2[9, 6] = new Spilleplade(btn2J7, ' ', 97);
            spilleplade2[9, 7] = new Spilleplade(btn2J8, ' ', 98);
            spilleplade2[9, 8] = new Spilleplade(btn2J9, ' ', 99);
            spilleplade2[9, 9] = new Spilleplade(btn2J10, ' ', 100);


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    spilleplade1[i, j].GetFelt.Click += Button_Click;
                    spilleplade2[i, j].GetFelt.Click += Button_Click;
                }
            }

            Placerskibe();











        }

        private void BeskedKontrol()
        {
            serverStream = clientSocket.GetStream();
            int buffSize = 0;
            byte[] inStream = new byte[10025];
            buffSize = clientSocket.ReceiveBufferSize;
            serverStream.Read(inStream, 0, 256);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            readData = "" + returndata;

            switch (readData.Substring(0, 1))
            {
                case "p":
                    Placerskibe();
                    break;


            }

        }

        public void Placerskibe()
        {
            if (hangarskibAntal == 0 && krysserAntal ==0 && detroyerAntal == 0 && patruleAntal == 0 && ubådAntal == 0)
            {
                btnHangaskib.Visible = true;
                btnKrysser.Visible = true;
                btnDestroyer.Visible = true;
                btnPatrule.Visible = true;
                btnUbåd.Visible = true;
                btnRoation.Visible = true;
                lblRotation.Visible = true;
                BtnPlacerIgen.Visible = turn;
                lblSkibe.Visible = true;
            }
            
            if (hangarskibAntal == 1)
            {
                
                btnHangaskib.Visible = false;
                hangarskib = false;
            }
            if (krysserAntal == 2)
            {
                
                btnKrysser.Visible = false;
                krysser = false;
            }
            if (detroyerAntal == 3)
            {
                
                btnDestroyer.Visible = false;
                detroyer = false;
            }
            if (patruleAntal == 4)
            {
                
                btnPatrule.Visible = false;
                patrule = false;
            }
            if (ubådAntal == 2)
            {
                
                btnUbåd.Visible = false;
                Ubåd = false;
            }
            if (hangarskibAntal == 1 && krysserAntal == 2 && detroyerAntal == 3 && patruleAntal == 4 && ubådAntal == 2)
            {
                
                BtnPlacerIgen.Visible = true;
                BtnPlaceingGodkendt.Visible = true;
            }
        }

        private void BtnHangaskib_Click(object sender, EventArgs e)
        {
            hangarskib = true;
            krysser = false;
            detroyer = false;
            patrule = false;
            Ubåd = false;





        }

        private void Button_Click(object sender, EventArgs e)
        {


            Button valgtfelt = sender as Button;
            //MessageBox.Show(valgtKnap.GetPlads.ToString());
            if (valgtKnap == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (turn == true)//måske fjernes?
                        {
                            if (valgtfelt == spilleplade1[i, j].GetFelt)
                            {
                                valgtKnap = spilleplade1[i, j];
                                
                                
                                    if (rotaion == true)
                                    {
                                        if (hangarskib == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[i, 9] || spilleplade1[i, j] == spilleplade1[i, 8] || spilleplade1[i, j] == spilleplade1[i, 7] || spilleplade1[i, j] == spilleplade1[i, 6])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }
                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i, j + 1].GetMaerke == ' ' && spilleplade1[i, j + 2].GetMaerke == ' ' && spilleplade1[i, j + 3].GetMaerke == ' '&& spilleplade1[i, j + 4].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "H";
                                                    spilleplade1[i, j + 1].GetFelt.Text = "H";
                                                    spilleplade1[i, j + 2].GetFelt.Text = "H";
                                                    spilleplade1[i, j + 3].GetFelt.Text = "H";
                                                    spilleplade1[i, j + 4].GetFelt.Text = "H";
                                                    spilleplade1[i, j].GetMaerke = 'H';
                                                    spilleplade1[i, j + 1].GetMaerke = 'H';
                                                    spilleplade1[i, j + 2].GetMaerke = 'H';
                                                    spilleplade1[i, j + 3].GetMaerke = 'H';
                                                    spilleplade1[i, j + 4].GetMaerke = 'H';
                                                    hangarskibAntal += 1;

                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        

                                        }
                                        else if (krysser == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[i, 9] || spilleplade1[i, j] == spilleplade1[i, 8]|| spilleplade1[i, j] == spilleplade1[i, 7])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }
                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i, j + 1].GetMaerke == ' ' && spilleplade1[i, j + 2].GetMaerke == ' ' && spilleplade1[i, j + 3].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "K";
                                                    spilleplade1[i, j + 1].GetFelt.Text = "K";
                                                    spilleplade1[i, j + 2].GetFelt.Text = "K";
                                                    spilleplade1[i, j + 3].GetFelt.Text = "K";
                                                    spilleplade1[i, j].GetMaerke = 'K';
                                                    spilleplade1[i, j + 1].GetMaerke = 'K';
                                                    spilleplade1[i, j + 2].GetMaerke = 'K';
                                                    spilleplade1[i, j + 3].GetMaerke = 'K';
                                                    krysserAntal += 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                        else if (detroyer == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[i, 9] || spilleplade1[i, j] == spilleplade1[i, 8])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }
                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i, j + 1].GetMaerke == ' ' && spilleplade1[i, j + 2].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "D";
                                                    spilleplade1[i, j + 1].GetFelt.Text = "D";
                                                    spilleplade1[i, j + 2].GetFelt.Text = "D";
                                                    spilleplade1[i, j].GetMaerke = 'D';
                                                    spilleplade1[i, j + 1].GetMaerke = 'D';
                                                    spilleplade1[i, j + 2].GetMaerke = 'D';
                                                    detroyerAntal += 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                        else if (patrule == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[i, 9])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }

                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i, j + 1].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "P";
                                                    spilleplade1[i, j + 1].GetFelt.Text = "P";
                                                    spilleplade1[i, j].GetMaerke = 'P';
                                                    spilleplade1[i, j + 1].GetMaerke = 'P';
                                                    patruleAntal += 1; 
                                                }
                                                else
                                                {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                        else if (Ubåd == true)
                                        {
                                            if(spilleplade1[i, j] == spilleplade1[i, 9])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }
                                            
                                            else 
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i, j + 1].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "U";
                                                    spilleplade1[i, j + 1].GetFelt.Text = "U";
                                                    spilleplade1[i, j].GetMaerke = 'U';
                                                    spilleplade1[i, j + 1].GetMaerke = 'U';
                                                    ubådAntal += 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }


                                    }
                                    else if (rotaion == false)
                                    {
                                        if (hangarskib == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[9,j] || spilleplade1[i, j] == spilleplade1[8, j] || spilleplade1[i, j] == spilleplade1[7, j] || spilleplade1[i, j] == spilleplade1[6, j])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }
                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i+1, j].GetMaerke == ' ' && spilleplade1[i+2, j ].GetMaerke == ' ' && spilleplade1[i+3, j ].GetMaerke == ' ' && spilleplade1[i+4, j ].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "H";
                                                    spilleplade1[i + 1, j ].GetFelt.Text = "H";
                                                    spilleplade1[i + 2, j ].GetFelt.Text = "H";
                                                    spilleplade1[i + 3, j ].GetFelt.Text = "H";
                                                    spilleplade1[i + 4, j ].GetFelt.Text = "H";
                                                    spilleplade1[i, j].GetMaerke = 'H';
                                                    spilleplade1[i + 1, j ].GetMaerke = 'H';
                                                    spilleplade1[i + 2, j ].GetMaerke = 'H';
                                                    spilleplade1[i + 3, j ].GetMaerke = 'H';
                                                    spilleplade1[i + 4, j ].GetMaerke = 'H';
                                                    hangarskibAntal += 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                        else if (krysser == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[9, j] || spilleplade1[i, j] == spilleplade1[8, j] || spilleplade1[i, j] == spilleplade1[7, j])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }
                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i + 1, j ].GetMaerke == ' ' && spilleplade1[i + 2, j ].GetMaerke == ' ' && spilleplade1[i + 3, j ].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "K";
                                                    spilleplade1[i + 1, j ].GetFelt.Text = "K";
                                                    spilleplade1[i + 2, j ].GetFelt.Text = "K";
                                                    spilleplade1[i + 3, j ].GetFelt.Text = "K";
                                                    spilleplade1[i, j].GetMaerke = 'K';
                                                    spilleplade1[i + 1, j ].GetMaerke = 'K';
                                                    spilleplade1[i + 2, j ].GetMaerke = 'K';
                                                    spilleplade1[i + 3, j ].GetMaerke = 'K';
                                                    krysserAntal += 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                        else if (detroyer == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[9, j] || spilleplade1[i, j] == spilleplade1[8, j])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }
                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i + 1, j ].GetMaerke == ' ' && spilleplade1[i + 2, j ].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "D";
                                                    spilleplade1[i + 1, j ].GetFelt.Text = "D";
                                                    spilleplade1[i + 2, j ].GetFelt.Text = "D";
                                                    spilleplade1[i, j].GetMaerke = 'D';
                                                    spilleplade1[i + 1, j ].GetMaerke = 'D';
                                                    spilleplade1[i + 2, j ].GetMaerke = 'D';
                                                    detroyerAntal += 1; 
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                        else if (patrule == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[9, i])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }

                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i + 1, j ].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "P";
                                                    spilleplade1[i + 1, j ].GetFelt.Text = "P";
                                                    spilleplade1[i, j].GetMaerke = 'P';
                                                    spilleplade1[i + 1, j ].GetMaerke = 'P';
                                                    patruleAntal += 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                        else if (Ubåd == true)
                                        {
                                            if (spilleplade1[i, j] == spilleplade1[9, j])
                                            {
                                                MessageBox.Show("Du kan ikke placere et skib her");
                                            }

                                            else
                                            {
                                                if (spilleplade1[i, j].GetMaerke == ' ' && spilleplade1[i + 1, j ].GetMaerke == ' ')
                                                {
                                                    spilleplade1[i, j].GetFelt.Text = "U";
                                                    spilleplade1[i + 1, j ].GetFelt.Text = "U";
                                                    spilleplade1[i, j].GetMaerke = 'U';
                                                    spilleplade1[i + 1, j ].GetMaerke = 'U';
                                                    ubådAntal += 1;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Du kan ikke placere et skib her");
                                                }
                                            }
                                        }
                                    }
                                valgtKnap = null;
                            }
                        }

                    }
                }

            }
            Placerskibe();
            
        }



        private void BtnDestroyer_Click(object sender, EventArgs e)
        {
            hangarskib = false;
            krysser = false;
            detroyer = true;
            patrule = false;
            Ubåd = false;
        }

        private void BtnPatrule_Click(object sender, EventArgs e)
        {
            hangarskib = false;
            krysser = false;
            detroyer = false;
            patrule = true;
            Ubåd = false;
        }

        private void BtnUbåd_Click(object sender, EventArgs e)
        {
            hangarskib = false;
            krysser = false;
            detroyer = false;
            patrule = false;
            Ubåd = true;
        }

        private void BtnRoation_Click(object sender, EventArgs e)
        {
            //skibet vender vandret og skifter den til at ligge lodret
            if (rotaion == false)
            {
                rotaion = true;
                btnRoation.Text = "vandret";
            }
            //skibet vender lodret
            else if (rotaion == true)
            {
                rotaion = false;
                btnRoation.Text = "lodret";
            }
        }

        private void BtnKrysser_Click(object sender, EventArgs e)
        {
            hangarskib = false;
            krysser = true;
            detroyer = false;
            patrule = false;
            Ubåd = false;
        }

        private void BtnPlacerIgen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    spilleplade1[i, j].GetFelt.Text = "";
                    spilleplade1[i, j].GetMaerke = ' ';

                    hangarskibAntal = 0;
                    krysserAntal = 0;
                    detroyerAntal = 0;
                    patruleAntal = 0;
                    ubådAntal = 0;

                    Placerskibe();
                    BtnPlaceingGodkendt.Visible = false;


                }
            }
        }

        private void BtnPlaceingGodkendt_Click(object sender, EventArgs e)
        {
            if (hangarskibAntal == 1 && krysserAntal == 2 && detroyerAntal == 3 && patruleAntal == 4 && ubådAntal == 2)
            {
                tableLayoutPanel1.Enabled = true;
                
            }
        } 
    }





}

