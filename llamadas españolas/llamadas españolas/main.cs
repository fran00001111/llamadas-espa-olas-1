using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;
using System.Reflection;

namespace llamadas_españa
{
    public class Main : Plugin
    {

        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += onOnDutyStateChangedHandler;
            Game.LogTrivial("Plugin llamadasespañolas" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()"By Author has benn initialised.");
            Game.LogTrivial("go on duty to fully load llamadas españolas");

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(LSPDFRResolveEventHandler);
        }
        public override void Finally()
        {
            Game.LogTrivial("llamadasespañolas has been cleaned up.");
        }


        private static void onOnDutyStateChangedHandler(bool OnDuty)
        {
            if (OnDuty)
            {
                RegisterCallouts();
                Game.DisplayNotification("llamadasespañolas by author Version 1.0.0  Alpha- Has been successfully loaded!");
            }
        }
        private static void RegisterCallouts()
        {
          Functions.RegisterCallouts(typeof(Callouts.HignSpeedChase));
        }


        public static Assembly LSPDRResolveEventHalder(object sender, ResolveEventArgs args)
        {
            foreach (Assembly assembly in Functions.GetAllUserPlugins())
            {
                if (args.Name.tolwer().contains(assembly.GetName().Name.ToLower()))
                {
                    return assembly;
                }
            }
            return null;
        }
    }
    public static bool IslSPDFRPluginrunning(string plugin, Version minversion = null)
    {
        foreach (Assembly assembly in functions.GetAllUserPlugins())
    }
     {
       AssemblyName an = Assembly.GetName(); 
        if (an.Name.Tolower()== Plugin.Tolower())
        {
        if (minversion == null  an.Version.compareTo(minversion)=0)
        {
        return true;
        }
      }
         return false;
      }
      
    }
}
