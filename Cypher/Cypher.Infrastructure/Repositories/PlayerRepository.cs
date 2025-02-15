﻿using Cypher.Application.Interfaces.Repositories;
using Cypher.Domain.Entities.Cypher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypher.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IRepositoryAsync<Player> _repo;
        private readonly IDistributedCache _distributedCache;

        public PlayerRepository(IRepositoryAsync<Player> repository, IDistributedCache distributedCache)
        {
            _repo = repository;
            _distributedCache = distributedCache;
        }

        public IQueryable<Player> Players => _repo.Entities;

        public async Task DeleteAsync(Player player)
        {
            await _repo.DeleteAsync(player);
            await _distributedCache.RemoveAsync(CacheKeys.PlayerCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.PlayerCacheKeys.GetKey(player.Id));
        }

        public void RemoveFriend(Player player, Player friend)
        {
            var friendToRemove = player.Friends.Where(f => f.Id == friend.Id).FirstOrDefault();
            player.Friends.Remove(friendToRemove);
        }

        public async Task<Player> GetByIdAsync(int playerId)
        {
            return await _repo.Entities
                .Where(p => p.Id == playerId)
                .Include(m=>m.MessagePlayers)
                .Include(p => p.Friends)
                .Include(i => i.Inventory)
                .ThenInclude(e => e.Items)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Player>> GetListAsync()
        {
            return await _repo.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Player player)
        {
            await _repo.AddAsync(player);
            await _distributedCache.RemoveAsync(CacheKeys.PlayerCacheKeys.ListKey);
            return player.Id;
        }

        public async Task UpdateAsync(Player player)
        {
            await _repo.UpdateAsync(player);
            await _distributedCache.RemoveAsync(CacheKeys.PlayerCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.PlayerCacheKeys.GetKey(player.Id));
        }

        public Task RemoveFriendAsync(Player player, Player friend)
        {
            throw new NotImplementedException();
        }
    }
}
