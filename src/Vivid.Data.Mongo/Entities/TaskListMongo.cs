﻿using MongoDB.Driver;
using Vivid.Data.Abstractions.Entities;

namespace Vivid.Data.Mongo.Entities
{
    public class TaskListMongo : TaskList
    {
        public MongoDBRef OwnerDbRef
        {
            get => _ownerDbRef;
            set
            {
                _ownerDbRef = value;
                OwnerId = OwnerDbRef?.Id.AsString;
            }
        }

        private MongoDBRef _ownerDbRef;

        public static TaskListMongo FromTaskList(TaskList taskList) => new TaskListMongo
        {
            Id = taskList.Id,
            DisplayId = taskList.DisplayId,
            OwnerId = taskList.OwnerId,
            Title = taskList.Title,
        };
    }
}