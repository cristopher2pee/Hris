using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Config
{
    public class TemplateConfig
    {
        public string GetReference(Guid departmentId)
        {
            return $"department/{departmentId}/template";
        }
    }

    public class TaskFileConfig
    {
        public string GetReference(Guid taskId)
        {
            return $"task/{taskId}";
        }
    }
}
