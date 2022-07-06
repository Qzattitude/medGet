using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medGet.Controllers.DbController;
using medGet.Models.Cart;
using medGet.Models;
using Microsoft.AspNetCore.Identity;
using medGet.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace medGet.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public OrderController(AppDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // GET: Order
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index()
        {
            var currentUser = UserManager.GetUserName(HttpContext.User);
            return _context.OrderProduct != null ? 
                          View(await _context.OrderProduct
                          .Where(p => p.OrderStatus.Equals(false) && p.UserName.Equals(currentUser)).ToListAsync()) :
                          Problem("Entity set 'AppDbContext.OrderProduct'  is null.");
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.OrderProduct == null)
            {
                return NotFound();
            }

            var orderProduct = await _context.OrderProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            return View(orderProduct);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Add(Guid? Id)
        {
            var currentUser = UserManager.GetUserName(HttpContext.User);
                //UserManager.GetUserName(HttpContext.User);
            if (currentUser != null)
            {
                //checks for existing order
                var ExistingOrder = await _context.OrderProduct
                    .Where(p => (p.ProductId.Equals(Id) && p.OrderStatus.Equals(false) && p.UserName.Equals(currentUser)))
                    .Select(q => q.Id).FirstOrDefaultAsync();
                //if empty, then add new product to cart
                if (ExistingOrder.Equals(Guid.Empty))
                {
                    //takes product details
                    var ProductDetails = await _context.PriceVariation
                        .Where(p => p.Id.Equals(Id)).FirstAsync();
                    //get non completed cart id

                    var getCartCount = await _context.OrderProduct.Where(p => p.OrderStatus.Equals(false))
                        .Select(q => q.CartId).CountAsync();
                    //if a cart alredy existed
                    if (getCartCount.Equals(0))
                    {
                        OrderProduct NewOrder = new OrderProduct()
                        {
                            Id = Guid.NewGuid(),
                            CartId = Guid.NewGuid(),
                            UserName = currentUser,
                            OrderStatus = false,
                            ProductId = ProductDetails.Id,
                            ProductBrand = ProductDetails.BrandName,
                            Price = ProductDetails.Price,
                            TotalCostProduct = ProductDetails.Price,
                            Qunatity = 1
                        };
                        await _context.AddAsync(NewOrder);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Order");
                    }
                    else
                    {
                        var getExistingCartId = await _context.OrderProduct.Where(p => p.OrderStatus.Equals(false))
                        .Select(q => q.CartId).FirstAsync();
                        OrderProduct NewOrder = new OrderProduct()
                        {
                            Id = Guid.NewGuid(),
                            CartId = getExistingCartId,
                            UserName = currentUser,
                            OrderStatus = false,
                            ProductId = ProductDetails.Id,
                            ProductBrand = ProductDetails.BrandName,
                            Price = ProductDetails.Price,
                            TotalCostProduct = ProductDetails.Price,
                            Qunatity = 1
                        };
                        await _context.AddAsync(NewOrder);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Order");
                    }
                    
                }
                else
                {
                    //do nothing
                }
            }
            return RedirectToAction("Index","Order");
        }

        #region Default Create
        // GET: Order/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Order/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserName,OrderId,OrderStatus,ProductId,ProductBrand,Price,Qunatity")] OrderProduct orderProduct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        orderProduct.Id = Guid.NewGuid();
        //        _context.Add(orderProduct);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(orderProduct);
        //}
        #endregion
        // GET: Order/Edit/5
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.OrderProduct == null)
            {
                return NotFound();
            }

            var orderProduct = await _context.OrderProduct.FindAsync(id);
            if (orderProduct == null)
            {
                return NotFound();
            }
            return View(orderProduct);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        #region deafult Edit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserName,OrderId,OrderStatus,ProductId,ProductBrand,Price,Qunatity")] OrderProduct orderProduct)
        //{
        //    if (id != orderProduct.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(orderProduct);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderProductExists(orderProduct.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(orderProduct);
        //}

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserName,OrderId,OrderStatus,ProductId,CartId,ProductBrand,TotalAmount,Price,Qunatity")] OrderProduct orderProduct)
        {
            if (id != orderProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    orderProduct.TotalCostProduct = orderProduct.Qunatity * orderProduct.Price;
                    _context.Update(orderProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderProductExists(orderProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderProduct);
        }

        // GET: Order/Delete/5
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.OrderProduct == null)
            {
                return NotFound();
            }

            var orderProduct = await _context.OrderProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            return View(orderProduct);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.OrderProduct == null)
            {
                return Problem("Entity set 'AppDbContext.OrderProduct'  is null.");
            }
            var orderProduct = await _context.OrderProduct.FindAsync(id);
            if (orderProduct != null)
            {
                _context.OrderProduct.Remove(orderProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderProductExists(Guid id)
        {
          return (_context.OrderProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderPlaced(Guid id, [Bind("Id,UserName,OrderId,OrderStatus,ProductId,ProductBrand,Price,Qunatity")] OrderProduct orderProduct)
        {
            if (id != orderProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderProductExists(orderProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderProduct);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Previous(PreviousOrderViewModel model)
        {
            var currentuser = UserManager.GetUserName(HttpContext.User);
            var ExistanceOfPreviousOrder = await _context.OrderProduct
                .Where(p => p.OrderStatus.Equals(true) 
                && p.UserName.Equals(currentuser))
                .OrderByDescending(p => p.DateTime).CountAsync();
            if (ExistanceOfPreviousOrder != 0)
            {
                model.OrderProduct = await _context.OrderProduct
                .Where(p => p.OrderStatus.Equals(true) && p.UserName.Equals(currentuser))
                .OrderByDescending(p => p.DateTime).ToListAsync();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Order");
            }
            
        }
        public IActionResult AdminSale()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminSale(AdminSaleViewModel model)
        {

            model.OrderProduct = await _context.OrderProduct
                .Where(p => p.OrderStatus.Equals(true))
                .OrderByDescending(p => p.DateTime).ThenBy(q=>q.CartId).ThenBy(r=>r.UserName).ToListAsync();

            var pricelist = await _context.OrderProduct.Select(q => q.TotalCostProduct).ToListAsync();
            double amount = 0.0d;
            foreach (var cost in pricelist)
            {
                amount += cost;
            }
            model.TotalEarning = Math.Round(amount, 2);
            return View(model);
        }
    }
}
