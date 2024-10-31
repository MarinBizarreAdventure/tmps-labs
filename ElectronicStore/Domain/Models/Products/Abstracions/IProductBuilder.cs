namespace Domain.Models.Products.Abstracions;

public interface IProductBuilder
{
    IProductBuilder SetId(string id);
    IProductBuilder SetName(string name);
    IProductBuilder SetDescription(string description);
    IProductBuilder SetPrice(decimal price);
    IProductBuilder SetBrand(string brand);
    IProductBuilder SetColor(string color);
    IProductBuilder SetStockQuantity(int stockQuantity);
    IProductBuilder SetOperatingSystem(string os);
    IProductBuilder SetProcessor(string processor);
    IProductBuilder SetRam(short ram);
    IProductBuilder SetGraphicsCard(string graphicsCard);
    IProductBuilder SetIsTouchscreen(bool isTouchscreen);
    IProductBuilder SetHasCellular(bool hasCellular);
    IProductBuilder SetHasStylusSupport(bool hasStylusSupport);
    IProductBuilder SetCameraResolution(int cameraResolution);
    IProductBuilder SetIs5GEnabled(bool is5GEnabled);
    IProduct Build();
}
