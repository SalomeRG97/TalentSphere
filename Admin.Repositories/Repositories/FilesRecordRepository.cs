using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class FilesRecordRepository : Repository<FileRecord>, IFilesRecordRepository
    {
        public FilesRecordRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}