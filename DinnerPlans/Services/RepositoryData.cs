namespace DinnerPlans.Services
{
    internal class RepositoryData
    {
        public RepositoryType Type;
        public string DefaultRepoFolder;
        public string RepoName;
        public string RepoFolderPath;

        public string FullPath
        {
            get { return RepoFolderPath + RepoName; }
        }
    }
}