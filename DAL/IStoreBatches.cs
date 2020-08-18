using System;
using System.Collections.Generic;

using ComITBakery.Models;

namespace ComITBakery.DAL
{
    public interface IStoreBatches
    {
        void CreateBatch(Batch batchToCreate);

        void UpdateBatch(Batch batchToUpdate);

        void DeleteBatch(Guid id);
    }
}