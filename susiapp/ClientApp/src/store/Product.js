const requestProductType = 'REQUEST_PRODUCT';
const receiveProductType = 'RECEIVE_PRODUCT';
const requestProductsType = 'REQUEST_PRODUCTS';
const receiveProductsType = 'RECEIVE_PRODUCTS';

const initialState = { product: 0, products: [], isLoading: false };

export const actionCreators = {
	requestProducts: () => async (dispatch, getState) => {
		dispatch({ type: requestProductsType });
		const url = `api/product/GetAllProduct`;
		const response = await fetch(url);
		const products = await response.json();

		dispatch({ type: receiveProductsType, products: products });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;
	
	if (action.type === requestProductsType) {
		return {
			...state,
			isLoading: true
		};
	}

	if (action.type === receiveProductsType) {
		return {
			...state,
			products: action.products,
			isLoading: false
		};
	}

	return state;
};
