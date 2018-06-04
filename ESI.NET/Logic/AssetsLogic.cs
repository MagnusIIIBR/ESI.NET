﻿using ESI.NET.Models.Assets;
using ESI.NET.Models.SSO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static ESI.NET.ApiRequest;

namespace ESI.NET.Logic
{
    public class AssetsLogic
    {
        private HttpClient _client;
        private ESIConfig _config;
        private AuthorizedCharacterData _data;
        private int character_id, corporation_id;

        public AssetsLogic(HttpClient client, ESIConfig config, AuthorizedCharacterData data = null)
        {
            _client = client;
            _config = config;
            _data = data;

            if (data != null)
            {
                character_id = data.CharacterID;
                corporation_id = data.CorporationID;
            }
        }

        /// <summary>
        /// /characters/{character_id}/assets/
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<Item>>> ForCharacter(int page = 1)
            => await Execute<List<Item>>(_client, _config, RequestSecurity.Authenticated, RequestMethod.GET, $"/characters/{character_id}/assets/", new string[]
            {
                $"page={page}"
            }, token: _data.Token);

        /// <summary>
        /// /characters/{character_id}/assets/locations/
        /// </summary>
        /// <param name="item_ids"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<ItemLocation>>> LocationsForCharacter(List<long> item_ids)
            => await Execute<List<ItemLocation>>(_client, _config, RequestSecurity.Authenticated, RequestMethod.POST, $"/characters/{character_id}/assets/locations/", body: item_ids.ToArray(), token: _data.Token);

        /// <summary>
        /// /characters/{character_id}/assets/names/
        /// </summary>
        /// <param name="item_ids"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<ItemName>>> NamesForCharacter(List<long> item_ids)
            => await Execute<List<ItemName>>(_client, _config, RequestSecurity.Authenticated, RequestMethod.POST, $"/characters/{character_id}/assets/names/", body: item_ids.ToArray(), token: _data.Token);


        /// <summary>
        /// /corporations/{corporation_id}/assets/
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<Item>>> ForCorporation(int page = 1)
            => await Execute<List<Item>>(_client, _config, RequestSecurity.Authenticated, RequestMethod.GET, $"/corporations/{corporation_id}/assets/", new string[]
            {
                $"page={page}"
            }, token: _data.Token);

        /// <summary>
        /// /corporations/{corporation_id}/assets/locations/
        /// </summary>
        /// <param name="item_ids"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<ItemLocation>>> LocationsForCorporation(List<long> item_ids)
            => await Execute<List<ItemLocation>>(_client, _config, RequestSecurity.Authenticated, RequestMethod.POST, $"/corporations/{corporation_id}/assets/locations/", body: item_ids.ToArray(), token: _data.Token);

        /// <summary>
        /// /corporations/{corporation_id}/assets/names/
        /// </summary>
        /// <param name="item_ids"></param>
        /// <returns></returns>
        public async Task<ApiResponse<List<ItemName>>> NamesForCorporation(List<long> item_ids)
            => await Execute<List<ItemName>>(_client, _config, RequestSecurity.Authenticated, RequestMethod.POST, $"/corporations/{corporation_id}/assets/names/", body: item_ids.ToArray(), token: _data.Token);
    }
}