using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;

namespace AutoToken
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            Autorizar autorizacionSAP = new Autorizar();
            txtLabel.Text = "Preparando Autenticación";
            txtLabel.Text = "Enviando Autenticación";
            //----------------------PROCESO DE AUTENTICACIÓN CON SAP USANDO CLIENT_ID Y CLIENT_SECRET-------------------------------------

            //Credenciales "hard-codeadas"

            string clientId = "TI2021";
            string secret = "689759eb-852c-4156-b1ae-c94f7e39dcc1";
            string token = autorizacionSAP.AutorizarSAP(clientId, secret);
            

            //------------------------------GENERAR QUERY EN BASE AL TOKEN OBTENIDO------------------------------------------
            Query quer = new Query();
            quer.RealizarQuery(token);

            txtLabel.Text = "Datos Insertados";

            
           



        }

      
    }
    
}
