
namespace Sitecore.Support.ContentSearch
{
    using System.Linq;
    using Sitecore.ContentSearch;

    public class SitecoreItemCrawler : Sitecore.ContentSearch.SitecoreItemCrawler
    {
        public SitecoreItemCrawler()
        {
        }

        public SitecoreItemCrawler(IIndexOperations indexOperations) : base(indexOperations)
        {
        }

        protected override void UpdateDependents(IProviderUpdateContext context, [NotNull]SitecoreIndexableItem indexable)
        {
            foreach (var uniqueId in GetIndexingDependencies(indexable).Where(i => !this.IsExcludedFromIndex(i, true)))
            {
                if (!this.CircularReferencesIndexingGuard.IsInProcessedList(uniqueId, this, context))
                    this.Update(context, uniqueId);
            }
        }

    }
}