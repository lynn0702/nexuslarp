using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace NexChar.App_Start
{
    public class HttpRequestLifetimeManager : LifetimeManager
    {
        private readonly string _key = Guid.NewGuid().ToString();

        public override object GetValue()
        {
            if (HttpContext.Current != null && HttpContext.Current.Items.Contains(_key))
                return HttpContext.Current.Items[_key];
            else
                return null;
        }

        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Remove(_key);
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[_key] = newValue;
        }
    }
}
