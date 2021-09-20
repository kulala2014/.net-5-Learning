using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace Kulala.Learning.WebApp.Utility
{
    public class IOCFactory
    {
        //容器只会初始化一次
        private static IUnityContainer _Container;

        private readonly static object IOCFactoryLock = new object();

        public static IUnityContainer GetContainer()
        {
            if (_Container == null)
            {
                lock (IOCFactoryLock)
                {
                    if (_Container == null)
                    {
                        //container.RegisterType
                        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
                        Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                        _Container = new UnityContainer();
                        section.Configure(_Container, "kulalaContainer");
                    }
                }
            }
            return _Container;
        }
    }
}