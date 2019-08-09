using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WeatherGrabber.Infrastructure.Repositories.Models;

namespace WeatherGrabber.Infrastructure.Repositories
{
    public class CityWeatherInfoRepository : Domain.Contracts.ICityWeatherInfoRepository
    {
        public CityWeatherInfoRepository()
        { }

        public IEnumerable<Domain.Models.CityWeatherInfo> GetAll()
        {
            try
            {
                using (var context = new CityWeatherInfoContext())
                {
                    return context.Cities.Select(c => new Domain.Models.CityWeatherInfo
                    {
                        CityId = c.CityId,
                        Name = c.Name,
                        TempDay = c.TempDay,
                        TempNight = c.TempNight,
                        WeatherComment = c.WeatherComment
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Domain.Exceptions.CityWeatherInfoRepositoryException(e.Message, e);
            }
        }

        public Domain.Models.CityWeatherInfo Get(int id)
        {
            try
            {
                using (var context = new CityWeatherInfoContext())
                {
                    var c = context.Cities.Find(id);
                    if (c == null)
                    {
                        return null;
                    }

                    return new Domain.Models.CityWeatherInfo
                    {
                        CityId = c.CityId,
                        Name = c.Name,
                        TempDay = c.TempDay,
                        TempNight = c.TempNight,
                        WeatherComment = c.WeatherComment
                    };
                }
            }
            catch (Exception e)
            {
                throw new Domain.Exceptions.CityWeatherInfoRepositoryException(e.Message, e);
            }
        }

        public void Create(Domain.Models.CityWeatherInfo item)
        {
            try
            {
                using (var context = new CityWeatherInfoContext())
                {
                    var daoModel = new CityWeatherInfo
                    {
                        CityId = item.CityId,
                        Name = item.Name,
                        TempDay = item.TempDay,
                        TempNight = item.TempNight,
                        WeatherComment = item.WeatherComment
                    };
                    context.Cities.Add(daoModel);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Domain.Exceptions.CityWeatherInfoRepositoryException(e.Message, e);
            }
        }

        public void Update(Domain.Models.CityWeatherInfo item)
        {
            try
            {
                using (var context = new CityWeatherInfoContext())
                {
                    var daoModel = new CityWeatherInfo
                    {
                        CityId = item.CityId,
                        Name = item.Name,
                        TempDay = item.TempDay,
                        TempNight = item.TempNight,
                        WeatherComment = item.WeatherComment
                    };
                    context.Entry(daoModel).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Domain.Exceptions.CityWeatherInfoRepositoryException(e.Message, e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new CityWeatherInfoContext())
                {
                    var info = context.Cities.Find(id);
                    if (info != null)
                    {
                        context.Cities.Remove(info);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Domain.Exceptions.CityWeatherInfoRepositoryException(e.Message, e);
            }
        }
    }
}
