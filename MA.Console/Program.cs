using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MAConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x=> 
            {
                x.Service<HeartBeat>(s=> {
                    s.ConstructUsing(heartBeat => new HeartBeat());
                    s.WhenStarted(heartBeat => heartBeat.Start());
                    s.WhenStopped(HeartBeat => HeartBeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("HearBeatService");
                x.SetDisplayName("HearBeatService");
                x.SetDescription("This is a simple heat beat service");

            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;

            Console.ReadKey();

            
        }
    }
}
