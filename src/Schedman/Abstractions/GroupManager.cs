﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedman.Abstractions
{
    public abstract class GroupManager<TPublish>
        where TPublish : PublishEntity
    {
        public abstract long Id { get; internal set; }
        public abstract string Title { get; internal set; }

        public abstract Task PublishAsync(TPublish post, Action<TPublish> onPublishFailed);
        public abstract Task<IEnumerable<TPublish>> GetPublishesAsync(int page, int count = 20);
    }
}