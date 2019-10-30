using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IzracunavanjeGotovosti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip1.AutoPopDelay = 1000000;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;

            int brojMinutaUNedelji = 10080; // 10080 minuta u nedelji
            int brojMinutaUMesecu = 43200; // 43200 minuta u mesecu
            int brojMinutaUGodini = 525600; // 525600 minuta u godini
            int UkupanBrojNeradnihMinutaNedeljniNivo; // pretvaranje unetih neradnih sata i minuta u minute
            int minutaURaduNedeljniNivo; // pretvaranje unetih radnih sati i minuta u minute
            int aktivnoVremeOpravkeMinutiNedelja; // pomnoze se uneti sati i minuti u aktivnoOpravke
            int slobodnoVremeNedelja; // vreme kada sistem ne radi ali je ispravan, ceka na rad (brojMinutaUNedelji-brojNeradnihMinuta-minutaURaduNedeljno)
            double ostvarenaGotovostNedelja;
            double unutrasnjaGotovostNedelja;
            double operativnaGotovostNedelja;

            int ukupanBrojNeradnihMinutaMesecniNivo;
            int minutaURaduMesecniNivo;
            int aktivnoVremeOpravkeMinutiMesec;
            int slobodnoVremeMesec;
            double ostvarenaGotovostMesec;
            double unutrasnjaGotovostMesec;
            double operativnaGotovostMesec;

            if (!string.IsNullOrWhiteSpace(tbRadniSati.Text) && !string.IsNullOrWhiteSpace(tbRadniMinuti.Text) &&
               !string.IsNullOrWhiteSpace(tbNeradnihSati.Text) && !string.IsNullOrWhiteSpace(tbNeradnihMinuta.Text)
               && !string.IsNullOrWhiteSpace(tbOpravkaSati.Text) && !string.IsNullOrWhiteSpace(tbOpravkaMinuta.Text)
               && Convert.ToInt32(tbRadniMinuti.Text) < 60 && Convert.ToInt32(tbNeradnihMinuta.Text) < 60 &&
               Convert.ToInt32(tbOpravkaMinuta.Text) < 60 && Convert.ToInt32(tbOpravkaSati.Text) < Convert.ToInt32(tbNeradnihSati.Text))
            {
                if (period == "nedeljno" && nivo == "nedeljnom"
                    && Convert.ToInt32(tbRadniSati.Text) < 168 && Convert.ToInt32(tbNeradnihSati.Text) < 168
                    && Convert.ToInt32(tbRadniSati.Text) + Convert.ToInt32(tbNeradnihSati.Text)<168)
                    
                {
                    if (Convert.ToInt32(tbOpravkaSati.Text) <= 0 && Convert.ToInt32(tbOpravkaMinuta.Text) <= 0)
                    {
                        UkupanBrojNeradnihMinutaNedeljniNivo = Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text);
                        minutaURaduNedeljniNivo = Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text);
                        ostvarenaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(UkupanBrojNeradnihMinutaNedeljniNivo));
                        ostvarenaGotovostNedelja = Math.Round(ostvarenaGotovostNedelja, 4);
                        label17.Text = ostvarenaGotovostNedelja.ToString();

                        slobodnoVremeNedelja = brojMinutaUNedelji - minutaURaduNedeljniNivo - UkupanBrojNeradnihMinutaNedeljniNivo;
                        operativnaGotovostNedelja = Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja)) / Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja + UkupanBrojNeradnihMinutaNedeljniNivo));
                        operativnaGotovostNedelja = Math.Round(operativnaGotovostNedelja, 4);
                        label13.Text = operativnaGotovostNedelja.ToString();

                        panel3.Visible = false;
                        MessageBox.Show("Nije moguce izracunati unutrasnju gotovost");
                    }
                    else
                    {
                        UkupanBrojNeradnihMinutaNedeljniNivo = Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text);
                        minutaURaduNedeljniNivo = Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text);
                        ostvarenaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(UkupanBrojNeradnihMinutaNedeljniNivo));
                        ostvarenaGotovostNedelja = Math.Round(ostvarenaGotovostNedelja, 4);
                        label17.Text = ostvarenaGotovostNedelja.ToString();

                        aktivnoVremeOpravkeMinutiNedelja = Convert.ToInt32(tbOpravkaSati.Text) * 60 + Convert.ToInt32(tbOpravkaMinuta.Text);
                        unutrasnjaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(aktivnoVremeOpravkeMinutiNedelja));
                        unutrasnjaGotovostNedelja = Math.Round(unutrasnjaGotovostNedelja, 4);
                        label22.Text = unutrasnjaGotovostNedelja.ToString();

                        slobodnoVremeNedelja = brojMinutaUNedelji - minutaURaduNedeljniNivo - UkupanBrojNeradnihMinutaNedeljniNivo;
                        operativnaGotovostNedelja = Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja)) / Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja + UkupanBrojNeradnihMinutaNedeljniNivo));
                        operativnaGotovostNedelja = Math.Round(operativnaGotovostNedelja, 4);
                        label13.Text = operativnaGotovostNedelja.ToString();
                    }
                }
                else if (period == "nedeljno" && nivo == "mesecnom"
                    && Convert.ToInt32(tbRadniSati.Text) < 720 && Convert.ToInt32(tbNeradnihSati.Text) < 720
                    && Convert.ToInt32(tbRadniSati.Text) + Convert.ToInt32(tbNeradnihSati.Text) < 720)
                { 
                    if(Convert.ToInt32(tbOpravkaSati.Text) <= 0 && Convert.ToInt32(tbOpravkaMinuta.Text) <= 0)
                    {
                        UkupanBrojNeradnihMinutaNedeljniNivo = (Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text)) * 4;
                        minutaURaduNedeljniNivo = (Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text)) * 4;
                        ostvarenaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(UkupanBrojNeradnihMinutaNedeljniNivo));
                        ostvarenaGotovostNedelja = Math.Round(ostvarenaGotovostNedelja, 4);
                        label17.Text = ostvarenaGotovostNedelja.ToString();

                        slobodnoVremeNedelja = brojMinutaUMesecu - minutaURaduNedeljniNivo - UkupanBrojNeradnihMinutaNedeljniNivo;
                        operativnaGotovostNedelja = Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja)) / Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja + UkupanBrojNeradnihMinutaNedeljniNivo));
                        operativnaGotovostNedelja = Math.Round(operativnaGotovostNedelja, 4);
                        label13.Text = operativnaGotovostNedelja.ToString();

                        panel3.Visible = false;
                        MessageBox.Show("Nije moguce izracunati unutrasnju gotovost");
                    }
                    else
                    {
                        UkupanBrojNeradnihMinutaNedeljniNivo = (Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text)) * 4;
                        minutaURaduNedeljniNivo = (Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text)) * 4;
                        ostvarenaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(UkupanBrojNeradnihMinutaNedeljniNivo));
                        ostvarenaGotovostNedelja = Math.Round(ostvarenaGotovostNedelja, 4);
                        label17.Text = ostvarenaGotovostNedelja.ToString();

                        aktivnoVremeOpravkeMinutiNedelja = (Convert.ToInt32(tbOpravkaSati.Text) * 60 + Convert.ToInt32(tbOpravkaMinuta.Text)) * 4;
                        unutrasnjaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(aktivnoVremeOpravkeMinutiNedelja));
                        unutrasnjaGotovostNedelja = Math.Round(unutrasnjaGotovostNedelja, 4);
                        label22.Text = unutrasnjaGotovostNedelja.ToString();

                        slobodnoVremeNedelja = brojMinutaUMesecu - minutaURaduNedeljniNivo - UkupanBrojNeradnihMinutaNedeljniNivo;
                        operativnaGotovostNedelja = Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja)) / Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja + UkupanBrojNeradnihMinutaNedeljniNivo));
                        operativnaGotovostNedelja = Math.Round(operativnaGotovostNedelja, 4);
                        label13.Text = operativnaGotovostNedelja.ToString();
                    }
                }
                else if (period == "nedeljno" && nivo == "godisnjem"
                    && Convert.ToInt32(tbRadniSati.Text) < 8760 && Convert.ToInt32(tbNeradnihSati.Text) < 8760
                    && Convert.ToInt32(tbRadniSati.Text) + Convert.ToInt32(tbNeradnihSati.Text) < 8760)
                {
                    if(Convert.ToInt32(tbOpravkaSati.Text) <= 0 && Convert.ToInt32(tbOpravkaMinuta.Text) <= 0)
                    {
                        UkupanBrojNeradnihMinutaNedeljniNivo = (Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text)) * 52;
                        minutaURaduNedeljniNivo = (Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text)) * 52;
                        ostvarenaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(UkupanBrojNeradnihMinutaNedeljniNivo));
                        ostvarenaGotovostNedelja = Math.Round(ostvarenaGotovostNedelja, 4);
                        label17.Text = ostvarenaGotovostNedelja.ToString();

                        slobodnoVremeNedelja = brojMinutaUGodini - minutaURaduNedeljniNivo - UkupanBrojNeradnihMinutaNedeljniNivo;
                        operativnaGotovostNedelja = Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja)) / Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja + UkupanBrojNeradnihMinutaNedeljniNivo));
                        operativnaGotovostNedelja = Math.Round(operativnaGotovostNedelja, 4);
                        label13.Text = operativnaGotovostNedelja.ToString();

                        panel3.Visible = false;
                        MessageBox.Show("Nije moguce izracunati unutrasnju gotovost");
                    }
                    else
                    {
                        UkupanBrojNeradnihMinutaNedeljniNivo = (Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text)) * 52;
                        minutaURaduNedeljniNivo = (Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text)) * 52;
                        ostvarenaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(UkupanBrojNeradnihMinutaNedeljniNivo));
                        ostvarenaGotovostNedelja = Math.Round(ostvarenaGotovostNedelja, 4);
                        label17.Text = ostvarenaGotovostNedelja.ToString();

                        aktivnoVremeOpravkeMinutiNedelja = (Convert.ToInt32(tbOpravkaSati.Text) * 60 + Convert.ToInt32(tbOpravkaMinuta.Text)) * 52;
                        unutrasnjaGotovostNedelja = Convert.ToDouble(minutaURaduNedeljniNivo) / (Convert.ToDouble(minutaURaduNedeljniNivo) + Convert.ToDouble(aktivnoVremeOpravkeMinutiNedelja));
                        unutrasnjaGotovostNedelja = Math.Round(unutrasnjaGotovostNedelja, 4);
                        label22.Text = unutrasnjaGotovostNedelja.ToString();

                        slobodnoVremeNedelja = brojMinutaUGodini - minutaURaduNedeljniNivo - UkupanBrojNeradnihMinutaNedeljniNivo;
                        operativnaGotovostNedelja = Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja)) / Convert.ToDouble((minutaURaduNedeljniNivo + slobodnoVremeNedelja + UkupanBrojNeradnihMinutaNedeljniNivo));
                        operativnaGotovostNedelja = Math.Round(operativnaGotovostNedelja, 4);
                        label13.Text = operativnaGotovostNedelja.ToString();
                    }
                }
                else if (period == "mesecno" && nivo == "mesecnom"
                    && Convert.ToInt32(tbRadniSati.Text) < 720 && Convert.ToInt32(tbNeradnihSati.Text) < 720
                    && Convert.ToInt32(tbRadniSati.Text) + Convert.ToInt32(tbNeradnihSati.Text) < 720)
                {
                    if(Convert.ToInt32(tbOpravkaSati.Text) <= 0 && Convert.ToInt32(tbOpravkaMinuta.Text) <= 0)
                    {
                        ukupanBrojNeradnihMinutaMesecniNivo = Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text);
                        minutaURaduMesecniNivo = Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text);
                        ostvarenaGotovostMesec = Convert.ToDouble(minutaURaduMesecniNivo) / (Convert.ToDouble(minutaURaduMesecniNivo) + Convert.ToDouble(ukupanBrojNeradnihMinutaMesecniNivo));
                        ostvarenaGotovostMesec = Math.Round(ostvarenaGotovostMesec, 4);
                        label17.Text = ostvarenaGotovostMesec.ToString();

                        slobodnoVremeMesec = brojMinutaUMesecu - minutaURaduMesecniNivo - ukupanBrojNeradnihMinutaMesecniNivo;
                        operativnaGotovostMesec = Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec)) / Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec + ukupanBrojNeradnihMinutaMesecniNivo));
                        operativnaGotovostMesec = Math.Round(operativnaGotovostMesec, 4);
                        label13.Text = operativnaGotovostMesec.ToString();

                        panel3.Visible = false;
                        MessageBox.Show("Nije moguce izracunati unutrasnju gotovost");
                    }
                    else
                    {
                        ukupanBrojNeradnihMinutaMesecniNivo = Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text);
                        minutaURaduMesecniNivo = Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text);
                        ostvarenaGotovostMesec = Convert.ToDouble(minutaURaduMesecniNivo) / (Convert.ToDouble(minutaURaduMesecniNivo) + Convert.ToDouble(ukupanBrojNeradnihMinutaMesecniNivo));
                        ostvarenaGotovostMesec = Math.Round(ostvarenaGotovostMesec, 4);
                        label17.Text = ostvarenaGotovostMesec.ToString();

                        aktivnoVremeOpravkeMinutiMesec = Convert.ToInt32(tbOpravkaSati.Text) * 60 + Convert.ToInt32(tbOpravkaMinuta.Text);
                        unutrasnjaGotovostMesec = Convert.ToDouble(minutaURaduMesecniNivo) / (Convert.ToDouble(minutaURaduMesecniNivo) + Convert.ToDouble(aktivnoVremeOpravkeMinutiMesec));
                        unutrasnjaGotovostMesec = Math.Round(unutrasnjaGotovostMesec, 4);
                        label22.Text = unutrasnjaGotovostMesec.ToString();

                        slobodnoVremeMesec = brojMinutaUMesecu - minutaURaduMesecniNivo - ukupanBrojNeradnihMinutaMesecniNivo;
                        operativnaGotovostMesec = Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec)) / Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec + ukupanBrojNeradnihMinutaMesecniNivo));
                        operativnaGotovostMesec = Math.Round(operativnaGotovostMesec, 4);
                        label13.Text = operativnaGotovostMesec.ToString();
                    }
                }
                else if (period == "mesecno" && nivo == "godisnjem"
                    && Convert.ToInt32(tbRadniSati.Text) < 8760 && Convert.ToInt32(tbNeradnihSati.Text) < 8760
                    && Convert.ToInt32(tbRadniSati.Text) + Convert.ToInt32(tbNeradnihSati.Text) < 8760)
                {
                    if(Convert.ToInt32(tbOpravkaSati.Text) <= 0 && Convert.ToInt32(tbOpravkaMinuta.Text) <= 0)
                    {
                        ukupanBrojNeradnihMinutaMesecniNivo = (Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text)) * 12;
                        minutaURaduMesecniNivo = (Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text)) * 12;
                        ostvarenaGotovostMesec = Convert.ToDouble(minutaURaduMesecniNivo) / (Convert.ToDouble(minutaURaduMesecniNivo) + Convert.ToDouble(ukupanBrojNeradnihMinutaMesecniNivo));
                        ostvarenaGotovostMesec = Math.Round(ostvarenaGotovostMesec, 4);
                        label17.Text = ostvarenaGotovostMesec.ToString();

                        slobodnoVremeMesec = brojMinutaUGodini - minutaURaduMesecniNivo - ukupanBrojNeradnihMinutaMesecniNivo;
                        operativnaGotovostMesec = Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec)) / Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec + ukupanBrojNeradnihMinutaMesecniNivo));
                        operativnaGotovostMesec = Math.Round(operativnaGotovostMesec, 4);
                        label13.Text = operativnaGotovostMesec.ToString();

                        panel3.Visible = false;
                        MessageBox.Show("Nije moguce izracunati unutrasnju gotovost");
                    }
                    else
                    {
                        ukupanBrojNeradnihMinutaMesecniNivo = (Convert.ToInt32(tbNeradnihSati.Text) * 60 + Convert.ToInt32(tbNeradnihMinuta.Text)) * 12;
                        minutaURaduMesecniNivo = (Convert.ToInt32(tbRadniSati.Text) * 60 + Convert.ToInt32(tbRadniMinuti.Text)) * 12;
                        ostvarenaGotovostMesec = Convert.ToDouble(minutaURaduMesecniNivo) / (Convert.ToDouble(minutaURaduMesecniNivo) + Convert.ToDouble(ukupanBrojNeradnihMinutaMesecniNivo));
                        ostvarenaGotovostMesec = Math.Round(ostvarenaGotovostMesec, 4);
                        label17.Text = ostvarenaGotovostMesec.ToString();

                        aktivnoVremeOpravkeMinutiMesec = (Convert.ToInt32(tbOpravkaSati.Text) * 60 + Convert.ToInt32(tbOpravkaMinuta.Text)) * 12;
                        unutrasnjaGotovostMesec = Convert.ToDouble(minutaURaduMesecniNivo) / (Convert.ToDouble(minutaURaduMesecniNivo) + Convert.ToDouble(aktivnoVremeOpravkeMinutiMesec));
                        unutrasnjaGotovostMesec = Math.Round(unutrasnjaGotovostMesec, 4);
                        label22.Text = unutrasnjaGotovostMesec.ToString();

                        slobodnoVremeMesec = brojMinutaUGodini - minutaURaduMesecniNivo - ukupanBrojNeradnihMinutaMesecniNivo;
                        operativnaGotovostMesec = Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec)) / Convert.ToDouble((minutaURaduMesecniNivo + slobodnoVremeMesec + ukupanBrojNeradnihMinutaMesecniNivo));
                        operativnaGotovostMesec = Math.Round(operativnaGotovostMesec, 4);
                        label13.Text = operativnaGotovostMesec.ToString();
                    }
                }
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                MessageBox.Show("Polja nisu pravilno popunjena, morate pokusati ponovo \n\n" +
                    "Do greske je doslo usled sledeceg: \n" +
                    "- Nisu sva polja popunjena\n" +
                    "- Broj minuta je veci od 60\n" +
                    "- Vreme koje ste uneli prelazi granicu perioda za koji se vodi\n" +
                    "- Uneto aktivno vreme opravke je vece od unetog vremena u otkazu\n", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string nivo;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nivo = cmbNivo.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbNeradnihSati.Clear();
            tbNeradnihMinuta.Clear();
            tbRadniSati.Clear();
            tbRadniMinuti.Clear();
            tbOpravkaSati.Clear();
            tbOpravkaMinuta.Clear();
            cmbNivo.Text = "";
            cmbPeriod.Text = "";
            label13.Text = "";
            label17.Text = "";
            label22.Text = "";
        }

        public string period;
        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            period = cmbPeriod.SelectedItem.ToString();

            cmbNivo.Items.Clear();
            if (cmbPeriod.SelectedItem == "nedeljno")
            {
                cmbNivo.Items.Add("nedeljnom");
                cmbNivo.Items.Add("mesecnom");
                cmbNivo.Items.Add("godisnjem");
            }
            else
            {
                cmbNivo.Items.Add("mesecnom");
                cmbNivo.Items.Add("godisnjem");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbRadniSati.Select();
            button3.BackColor = ColorTranslator.FromHtml("#002db3");
            button3.Enabled = true;
        }

        private void tbRadniSati_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikacija omogucava racunanje gotovosti.\n" +
                "Predvidjeno je da se za posmatrani uredjaj unose vreme u radu i vreme u otkazu " +
                "odnosno da uredjaj ne radi neprestano u toku vremenskog perioda za koji se vodi.\n\n" +
                "Slede napomene koje olaksavaju koriscenje aplikacije:\n\n" +
                "- U polja je dozvoljeno upisati samo brojeve i koristiti backspace i delete komande\n" +
                "- Voditi racuna da uneto vreme ne prelazi period za koje se vodi (npr. da broj sati na nedeljnom nivou ne moze biti veci od 168 i da broj minuta ne moze biti veci od 60...)\n" +
                "- Uneto aktivno vreme opravke mora biti manje od unetog vremena u otkazu uredjaja\n" +
                "- Ukoliko se ne unese aktivno vreme opravke, unutrasnja gotovost se nece prikazati\n" +
                "- Podaci se vode na nedeljnom i mesecnom nivou a mogu se racunati za nedeljni, mesecni i godisnji period\n" +
                "- Period za koji se podaci vode i nivo za koji se racunaju su medjusobno iskljucivi\n" +
                "- Klikom na dugme ponisti, omogucava se unos podataka iznova\n" +
                "- Rezultati gotovosti se zaokruzuju na 4 decimale\n" +
                "- Izracunate gotovosti mogu biti u intervalu od 0 do 1","Napomena",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}