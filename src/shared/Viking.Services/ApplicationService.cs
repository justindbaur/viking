using System;
using Viking.Contexts;
using Viking.Entities;

namespace Viking.Services
{
    public class ApplicationService
    {
        private readonly ApplicationContext context;

        public ApplicationService(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create<T>()
            where T : AuditableEntity, new()
        {

        }


        private void AuditCreation(ref AuditableEntity entity)
        {
            
        }
    }
}
