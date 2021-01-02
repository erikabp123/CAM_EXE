using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CAM_LAUNCHER {
    class Program {
        private static bool JAVA_INSTALLED = false;

        static void Main(string[] args) {
            JAVA_INSTALLED = isJavaInstalled();
            
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (JAVA_INSTALLED) startInfo.FileName = "java.exe";
            startInfo.FileName = @"system\jdk-12.0.2\bin\javaw.exe";
            startInfo.Arguments = @"-jar system\ClassicAddonManager.jar";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process.Start(startInfo);
        }

        private static Boolean isJavaInstalled() {
            try {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "java.exe";
                psi.Arguments = " -version";
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                Process pr = Process.Start(psi);
                string strOutput = pr.StandardError.ReadLine().Split(' ')[2].Replace("\"", "");
                Int32 versionNum = Int32.Parse(strOutput.Split('.')[1]);
                Debug.WriteLine(versionNum);
                return versionNum >= 8;
            }
            catch (Exception ex) {
                Debug.WriteLine("Exception is " + ex.Message);
                return false;
            }
        }
    }
}