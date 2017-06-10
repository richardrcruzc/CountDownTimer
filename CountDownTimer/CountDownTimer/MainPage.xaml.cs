using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CountDownTimer
{
    public partial class MainPage : ContentPage
    {
        
        int countMinutes = 5;
        int countSeconds = 0;
        int count = 0;

        bool pause = false;

        void OnBtnClickedReset(object sender, EventArgs e)
        {
              countMinutes = 5;
              countSeconds = 0;
              count = 0;
            CountDowntLabel.Text = String.Format("{0}:{1}", countMinutes, countSeconds.ToString("D2"));
            btnStartStop.Text = "Start";
        }
            void OnBtnClicked(object sender, EventArgs e)
        {

            if (btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Pause";
                btnPause.IsVisible = true;
                pause = false;
            }
            else if (btnStartStop.Text == "Pause")
            {
                btnStartStop.Text = "Start";
                pause = true;
            }


            ////start the timer going
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimeTickSeconds);
            Device.StartTimer(TimeSpan.FromMinutes(1), OnTimeTickMinutes);


          

        }
        public MainPage()
        {
            InitializeComponent(); 
            
            //set sizeChanged event on the page
            this.SizeChanged += OnPageSizeChanged;

            CountDowntLabel.Text = String.Format("{0}:{1}", countMinutes, countSeconds.ToString("D2"));            

        }
 

        private bool OnTimeTickSeconds()
        {
            if (pause)
                return false;

            // set the text property of label

            CountDowntLabel.Text = String.Format("{0}:{1}", countMinutes, countSeconds.ToString("D2"));

            countSeconds--;
            if (countSeconds <= 0  )
            {
                countSeconds = 60;
                countMinutes--;
                CountDowntLabel.Text = String.Format("{0}:{1}", countMinutes, countSeconds.ToString("D2"));
            }

            return true;
        }
        private bool OnTimeTickMinutes()
        {
            if (pause)
                return false;
            // set the text property of label
            CountDowntLabel.Text = String.Format("{0}:{1}", countMinutes, countSeconds.ToString("D2"));

            countMinutes--;
            if (countMinutes <= 0)
            {
                countMinutes = 5;
                countSeconds = 0;
                CountDowntLabel.Text = String.Format("{0}:{1}", countMinutes, countSeconds.ToString("D2"));
                
                return false;
            }
            countSeconds = 60;

            return true;
        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            //scale the font size to the page width
            //based on 11 characters in the display string
            if (this.Width > 0)
            {
                CountDowntLabel.FontAttributes = FontAttributes.Bold;
                CountDowntLabel.FontSize =(this.Width / 6);
                
            }
        }
    }
}
