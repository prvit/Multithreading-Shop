using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Controls;

namespace ShopService.Utilities
{
    public class TextBlockLogger
    {
        //*********************************************************************
        #region Construction
        //*********************************************************************
        /// <summary>
        /// 
        /// </summary>
        public TextBlockLogger()
        {
            IsDebugEnabled = true;
            IsInfoEnabled = true;
            IsWarnEnabled = true;
            IsErrorEnabled = true;
            IsFatalErrorEnabled = true;
        }
        #endregion

        //*********************************************************************
        #region Private Methods
        //*********************************************************************
        private void WriteToTextBlock(string msg)
        {
            if (Dispatcher != null)
            {
                Dispatcher.BeginInvoke(new Action(
                    delegate()
                    {
                        TextBlock.Text = TextBlock.Text + String.Format("{0}\n", msg);
                        if (ScrollViewer != null)
                        {
                            ScrollViewer.UpdateLayout();
                            ScrollViewer.ScrollToVerticalOffset(TextBlock.ActualHeight);

                        }
                    }));
            }
            else
            {
                TextBlock.Text = TextBlock.Text + String.Format("{0}\n", msg);
                if (ScrollViewer != null)
                {
                    ScrollViewer.UpdateLayout();
                    ScrollViewer.ScrollToVerticalOffset(TextBlock.ActualHeight);

                }

            }
        }
        #endregion

        //*********************************************************************
        #region Public Properties
        //*********************************************************************
        /// <summary>
        /// 
        /// </summary>
        public Dispatcher Dispatcher { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ScrollViewer ScrollViewer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextBlock TextBlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDebugEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsInfoEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsWarnEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFatalErrorEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsErrorEnabled { get; set; }
        #endregion

        //*********************************************************************
        #region Public Methods
        //*********************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            WriteToTextBlock(message.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception)
        {
            WriteToTextBlock(String.Format("{0} - {1}", message, exception));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args)
        {
            WriteToTextBlock(String.Format(format, args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            WriteToTextBlock(message.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception)
        {
            WriteToTextBlock(String.Format("{0} - {1}", message, exception));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
            WriteToTextBlock(String.Format(format, args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            WriteToTextBlock(message.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception)
        {
            WriteToTextBlock(String.Format("{0} - {1}", message, exception));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args)
        {
            WriteToTextBlock(String.Format(format, args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            WriteToTextBlock(message.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception)
        {
            WriteToTextBlock(String.Format("{0} - {1}", message, exception));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args)
        {
            WriteToTextBlock(String.Format(format, args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void FatalError(object message)
        {
            WriteToTextBlock(message.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void FatalError(object message, Exception exception)
        {
            WriteToTextBlock(String.Format("{0} - {1}", message, exception));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalErrorFormat(string format, params object[] args)
        {
            WriteToTextBlock(String.Format(format, args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //public ILogger CreateChildLogger(string name)
        //{
        //    TextBlockLogger logger = new TextBlockLogger();
        //    logger.Dispatcher = Dispatcher;
        //    logger.TextBlock = TextBlock;

        //    return logger;
        //}
        #endregion
    }
}
