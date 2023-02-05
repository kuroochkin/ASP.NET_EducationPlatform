using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Diagnostics;

namespace ASP.NET_EducationPlatform.Infrastructure.Conventions
{
    public class TestConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            Debug.WriteLine(controller.ControllerName);
        }
    }
}
