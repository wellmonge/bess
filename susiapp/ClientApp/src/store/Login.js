import request from 'super-request';
const authenticationRequestType = 'AUTHENTICATION_REQUEST';
const authenticationReceiveType = 'AUTHENTICATION_RECEIVE';

const initialState = { authorization = '', isLoading: false };

export const actionCreators = {
	authenticationRequest: (username, password) => async (dispatch, getState) => {
		dispatch({ type: authenticationReceiveType });
		const url = 'api/login/authenticationRequest';
		const response = await request.post(url, { username= username, password: password})
		const result = await response.json();
		dispatch({type: authenticationReceiveType, payload: result});
	},
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === authenticationRequestType) {
		return {
			...state,
			isLoading: true
		};
	}

	if (action.type === receiveUserType) {
		return {
			...state,
			authorization: action.payload,
			isLoading: false
		};
	}

	return state;
};
