<template>
  <div>
    <div class="product-search">
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
      this.$http.get("https://localhost:44389/api/Products/GetProducts").then(function(res){

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
  padding: 0 6px;
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
  border: 1px solid #fff;
}
.product-list li:hover{
border-color: #eee;
box-shadow: 0 0 6px #ccc;

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