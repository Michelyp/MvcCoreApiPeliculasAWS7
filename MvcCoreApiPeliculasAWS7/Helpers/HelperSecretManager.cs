﻿using Amazon;
using Amazon.Runtime.Internal;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace MvcCoreApiPeliculasAWS7.Helpers
{
    public class HelperSecretManager
    {
        public static async Task<string> GetSecretsAsync()
        {
            string secretName = "secretospeliculas";
            string region = "us-east-1";
            IAmazonSecretsManager client =
                new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));
            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };
            GetSecretValueResponse response;
            response = await client.GetSecretValueAsync(request);
            string secret = response.SecretString;
            return secret;
        }

    }
}