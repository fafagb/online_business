<template>
  <div>
    <div class="product-search"><!-- 搜索框的总宽度是624,button的总宽度是80，所以div的宽度要设置为大于等于704 ，高度大于等于最大高度的元素（div没设宽度的时候宽度是浏览器的宽度，高度是最大高度的元素的高度），当设置了其内元素float:left,这些元素就浮起来了(向左浮动，App.vue全局样式text-align: center失效)，此时它们就不和div在一个空间里了(虽然定位还在div里)，所以这个时候div就瘪掉了，高度就成0了，所以我们要把div宽高进行设置，为了能剧中，当我们设置完div的宽度后，就可以让magin设置auto，设置auto的意思是我div现在就这么宽，不够浏览器宽度的地方，magin左右边距平分浏览器，就达到了居中效果-->
      <input type="text" id="txtSearch" />
      <button>搜索</button>
    </div>
    <hr />
    <div class="product-list">
      <ul>
        <!-- 属性前面加：就可以直接使用vue变量 -->
        <li v-for="product in productList" :key="product.id"> 
          <img :src="product.productImageUrl" alt="" />
          <p class="p-price">&yen;{{product.price}}</p>
          <p>{{product.productName}}</p>
        </li>
        
      </ul>
    </div>
  </div>
</template>
<script>
export default {
  data(){

    return{

      productList:[]  //赋值未空数组，productList就是数组变量   
    };
  },
  mounted(){

    this.getProductList();
  },
  methods:{
    getProductList:function(){
     // var thisView=this.productList;
     var thisView=this;
      this.$http.get("https://localhost:5001/api/Products/GetProducts").then(function(res){

      //  thisView=res.data;//如果用jequrey的话：1res就是返回的数据。2这里this是jequrey对象，但我们这里用的是axios，这里的this是个null，所以要在外面接受productlist变量，不能直接在这里this.productlist-res.data
      thisView.productList=res.data;  //后端返回的是一个List对象，返回到前端，前端会自动转换成json数组，所以我们这里就用数组变量接收
      });

    }

  }
}
</script>
<style >
* {
  padding: 0;
  margin: 0;
}
.product-search {
  width: 704px;
  height: 44px;
  margin: auto;
}
#txtSearch {
  width: 600px;
  height: 32px;
  border: 6px solid red;
  float: left;
  outline: none;
  padding: 0 6px;  /* =0 6px 0 6px*/
}

button {
  width: 80px;
  height: 44px;
  border: 0 none;
  background: red;
  color: #fff;
  float: left;
  outline: none;
}
hr {
  margin-top: 60px;
  border: 2px solid red;
}
.product-list li {
  width: 260px;
  margin:60px 0 0 60px;
  list-style: none;
  float: left;
  border: 1px solid #fff;   /*鼠标放上去外边框显示效果：1边框要么透明，要么和背景色保持一致*/
}
.product-list li:hover{
border-color: #eee; /*鼠标放上去外边框显示效果：2然后鼠标放上来的时候改变边框的颜色，阴影效果就出来了*/
box-shadow: 0 0 6px #ccc;/*小阴影： 第一个0：x轴阴影偏移量，第二个0向下的阴影偏移量，这么设置就正向投影了*/

}
.product-list li img {
  width: 260px;
}
.product-list li p {
  text-align: left;
}

.p-price {
  font-size: 18px;
  font-weight: bold;
  color: red;
  margin-bottom: 8px;
}
</style>