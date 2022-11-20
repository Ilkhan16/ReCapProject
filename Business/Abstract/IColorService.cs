﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
    IDataResult<List<Color>> GetAll();
    IDataResult<Color> GetById(int id);
    IResult Add(Color color);
    IResult Delete(Color color);
    IResult Update(Color color);
}