using Elsa.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Elsa.WorkflowTesting.Handlers
{
    public class ConfigureWorkflowContextForTestHandler : INotificationHandler<WorkflowExecuting>
    {
        public Task Handle(WorkflowExecuting notification, CancellationToken cancellationToken)
        {
            var isTest = Convert.ToBoolean(notification.WorkflowExecutionContext.WorkflowInstance.GetMetadata("isTest"));

            // If we are in test mode, we always block on the first activity.
            if (isTest)
                notification.WorkflowExecutionContext.CompletePass();

            return Task.CompletedTask;
        }
    }
}