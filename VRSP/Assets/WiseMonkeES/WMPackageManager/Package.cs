using System;
using UnityEditor;
using UnityEngine;

namespace PackageManager
{
    [Serializable]
    public class Package
    {
        public string name;
        public string description;
        public string gitHubUrl;
        public Package[] dependencies;
        
        public Package(string name, string description, string gitHubUrl, Package[] dependencies)
        {
            this.name = name;
            this.description = description;
            this.gitHubUrl = gitHubUrl;
            this.dependencies = dependencies;
        }

    }
}