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
          <img :src="product.url" alt="" />
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

      productlist:[]
    };
  },
  mounted(){},
  methods:{
    getProductList:function(){
      var thisView=this.productlist;
      this.$http.get("/api/Products/GetProductList").then(function(res){

        thisView=res.data;//如果用jequrey的话：1res就是返回的数据。2这里this是jequrey对象，但我们这里用的是axios，这里的this是个null，所以要在外面接受productlist变量，不能直接在这里this.productlist-res.data
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