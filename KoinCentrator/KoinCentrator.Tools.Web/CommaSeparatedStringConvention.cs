using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace KoinCentrator.Tools.Web
{
    public class CommaSeparatedQueryStringConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            foreach (ParameterModel parameter in action.Parameters)
                if (parameter.Attributes.OfType<CommaSeparatedAttribute>().Any() && !parameter.Action.Filters.OfType<SeparatedQueryStringAttribute>().Any())
                    parameter.Action.Filters.Add(new SeparatedQueryStringAttribute(parameter.ParameterName, ","));
        }
    }
}
