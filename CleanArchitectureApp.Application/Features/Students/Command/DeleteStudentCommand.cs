using LMS_Api_App.Application.Interfaces.Repositories;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Student.Command
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public required int Id { get; set; }
    }
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentService _service;

        public DeleteStudentHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteStudentAsync(request.Id);
        }
    }
}
