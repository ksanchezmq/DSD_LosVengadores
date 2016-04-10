using System.ServiceProcess;
using System.Timers;
using System;
using System.Messaging;

namespace WhoIsBetter.WinService
{
    public partial class Scheduler : ServiceBase
    {
        Timer timer = null;

        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = 5000; //every 5 sec
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Enabled = true;
            
            Logger.WriteErrorLog("WhoIsBetter Scheduler service started");
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            Logger.WriteErrorLog("WhoIsBetter Scheduler service stopped");
        }

        protected void timer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                
                    //string rutaCola = @".\private$\DSWarrior2";

                    //if (!MessageQueue.Exists(rutaCola))
                    //{
                    //    MessageQueue.Create(rutaCola);
                    //}

                    //var cola = new MessageQueue(rutaCola);
                    //cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Favorito) });

                    //var totalMessages = cola.GetAllMessages().Count();

                    //for (int i = 0; i < totalMessages; i++)
                    //{
                    //    var mensaje = cola.Receive();
                    //    var favorito = (Favorito)mensaje.Body;
                            
                    //    proxyFavorito.CrearFavorito(favorito);
                    //}
                Logger.WriteErrorLog("Timer ticked has been done successfully");
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }

        }
    }
}
