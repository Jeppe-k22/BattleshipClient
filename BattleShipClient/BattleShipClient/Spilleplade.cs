using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient
{
    class Spilleplade
    {
        private Button felt;
        private char maerke;
        private int plads;

        public Spilleplade(Button _felt, char _maerke, int _plads)
        {
            felt = _felt;
            maerke = _maerke;
            plads = _plads;
        }
        public Button GetFelt
        {
            get { return felt; }
            set { felt = value; }

        }
        public char GetMaerke
        {
            get { return maerke; }
            set { maerke = value; }
        }
        public int GetPlads
        {
            get { return plads; }
            set { plads = value; }
        }
    }
}

