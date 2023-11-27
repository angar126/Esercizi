﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    static class Logger
    {
        private static readonly TextWriterTraceListener logFileListener;

        static Logger()
        {
            logFileListener = new TextWriterTraceListener("log.txt");
            Trace.Listeners.Add(logFileListener);

            // Abilita la registrazione degli errori
            Trace.AutoFlush = true;
        }

        public static void LogError(Exception ex)
        {
            Trace.TraceError($"Errore: {ex.Message}");
            Trace.TraceError($"Stack Trace: {ex.StackTrace}");
        }

        public static void LogInfo(string message)
        {
            // Registra un messaggio di informazione nel log
            Trace.TraceInformation(message);
        }
        public static void CloseLog()
        {
            logFileListener.Close();
        }
    }
}
