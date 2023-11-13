using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewRepo.DTO;
using NewRepo.Entity;
using NewRepo.Facade;
using NewRepo.IService;

namespace NewRepo.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderFacade _orderFacade;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IOrderFacade orderFacade, IMapper mapper)
        {
            _orderService = orderService;
            _orderFacade = orderFacade;
            _mapper = mapper;
        }
        [HttpGet("finalize")]
        public async Task<ActionResult> finalizeOrder([FromQuery] long id)
        {
            var order = await _orderService.GetById(id);
            await _orderFacade.finalizeOrder(order);
            return Ok("Order has been finalized");
        }
        [HttpGet("get/{orderId}")]
        public async Task<ActionResult> getOrderById(long orderId)
        {
            var order = await _orderService.GetById(orderId);
            return Ok(_mapper.Map<OrderByIdDTO>(order));
        }
        [HttpPost("insert")]
        public async Task<ActionResult> createOrder([FromBody] OrderDTO order)
        {
            await _orderService.Insert(_mapper.Map<Order>(order));
            return Ok("Order has been inserted");
        }
        [HttpPut("update/{orderId}")]
        public async Task<ActionResult> updateOrder([FromQuery] long orderId, [FromBody] OrderDTO order)
        {
            await _orderService.Update(orderId, _mapper.Map<Order>(order));
            return Ok("Order has been updated");
        }
        [HttpDelete("delete/{orderId}")]
        public async Task<ActionResult> deleteOrder([FromQuery] long orderId)
        {
            await _orderService.Delete(orderId);
            return Ok("Order has been deleted");
        }
        [HttpGet("get_all")]
        public async Task<ActionResult> getOrders()
        {
            var orders = _mapper.Map<IEnumerable<OrderDTO>>(await _orderService.GetAll());
            return Ok(orders);
        }
        [HttpPut("add_product")]
        public async Task<ActionResult> addProduct([FromQuery] long orderId, [FromQuery] long productId)
        {
            await _orderFacade.addProduct(orderId, productId);
            return Ok("Product has been added");
        }
        //ORDER BY FUTURE USER
        /*     [HttpGet]
           public ActionResult<IEnumerable<ProductDTO>> getOrdersByUser(User user)
           {
               var products = _mapper.Map<IEnumerable<ProductDTO>>(_service.getOrdersByUser());
               return Ok();
           }*/
    }
}
