using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class FilesRecordRepository : Repository<FilesRecord>, IFilesRecordRepository
    {
        public FilesRecordRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}