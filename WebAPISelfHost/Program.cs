using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;

namespace WebAPISelfHost
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Web Api监听  

            Assembly.Load("Interface");  //手工加载某个api程序集的controller(注意引用)

            var config = new HttpSelfHostConfiguration("http://localhost:8888");//端口号自定义配置  //服务器的本地地址

            config.Routes.MapHttpRoute("default", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

            // config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.EnableCors();//启动跨域
            var server = new HttpSelfHostServer(config);

            server.OpenAsync().Wait(); //开启监听
            Console.ReadLine();
            #endregion

            //安装windows services 
            //步骤：打开“cmd”命令窗口，输入“F:\Wrok\源码\ReleaseFile\FContainer.exe -install /EHECD”，这是我电脑所做的目录，请不要全盘复制
            //“-install”是参数表示要进行安装程序，“/EHECD”也是参数，表示所安装服务的名称
            //安装完成后打开系统服务窗口（命令行下输入“services.msc”），就哭找到我们刚刚所安装的服务，

        }
    }
}
